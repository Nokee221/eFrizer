import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/hairsalon/HairSalon.dart';
import 'package:flutter_login/models/text_review/text_review.dart';
import 'package:flutter_login/models/text_review/text_review_insert_request.dart';
import 'package:flutter_login/models/text_review/text_review_search_request.dart';
import 'package:flutter_login/pages/details.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class ReviewPage extends StatefulWidget {
  final HairSalon hairSalon;
  final ApplicationUser user;
  const ReviewPage(this.hairSalon, this.user, {Key? key}) : super(key: key);

  @override
  _ReviewPageState createState() => _ReviewPageState(hairSalon, user);
}

class _ReviewPageState extends State<ReviewPage> {
  final HairSalon hairSalon;
  final ApplicationUser user;

  _ReviewPageState(this.hairSalon, this.user);

  final String assetName = 'assets/hairdresser.svg';
  TextEditingController txtReview = new TextEditingController();

  var request = null;

  @override
  void initState() {
    super.initState();
    request = TextReviewSearchRequest(
        clientId: user.applicationUserId, hairSalonId: hairSalon.HairSalonId);
  }

  var result = null;
  var insertRequest = null;
  Future<void> putReview() async {
    if(txtReview.text == "")
    {
      result = null;
    }
    else{

      insertRequest = TextReviewInsertRequest(clientId: user.applicationUserId , hairsalonId: hairSalon.HairSalonId, text: txtReview.text);
      result = APIService.post("TextReview", insertRequest);
    }
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);

    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Text(
          "Review",
          style: GoogleFonts.pacifico(
              color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
        leading: BackButton(color: Colors.blue),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: Column(
        children: <Widget>[
          Padding(
            padding: const EdgeInsets.all(20.0),
            child: Container(
              padding: EdgeInsets.all(20.0),
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(20.0),
                boxShadow: [
                  BoxShadow(
                    color: Colors.grey,
                    blurRadius: 10.0,
                    spreadRadius: 1.0,
                    offset: Offset(4.0, 4.0),
                  ),
                ],
              ),
              child: Column(
                children: [
                  TextFormField(
                    controller: txtReview,
                    style: TextStyle(color: themeChange.darkTheme ? Colors.black : Colors.white),
                    maxLines: 3,
                    decoration: InputDecoration(
                      hintText: "Add a review",
                    ),
                  ),
                  SizedBox(
                    height: 28,
                  ),
                  RaisedButton(
                    child: Padding(
                      padding: EdgeInsets.symmetric(horizontal: 80),
                      child: Text(
                        "Add Review",
                        style: TextStyle(
                          color: Colors.white,
                          fontWeight: FontWeight.bold,
                          fontSize: 14.0,
                        ),
                      ),
                    ),
                    onPressed: () async{
                      await putReview();
                      if(result != null)
                      {
                        Widget okButton = TextButton(
                          child: Text("OK"),
                          onPressed: () {
                            Navigator.push(
                                    context,
                                    MaterialPageRoute(
                                        builder: (context) =>
                                            Details(hairSalon , user)));
                          },
                        );
                        AlertDialog alert = AlertDialog(
                          title: Text("Success"),
                          content: Text("Successfully added review!"),
                          actions: [
                            okButton,
                          ],
                        );
                        showDialog(
                            context: context,
                            builder: (BuildContext context) {
                              return alert;
                            });
                      }
                      else{
                        Widget okButton = TextButton(
                          child: Text("OK"),
                          onPressed: () {
                            Navigator.pop(context);
                          },
                        );
                        AlertDialog alert = AlertDialog(
                          title: Text("Error"),
                          content: Text("Text field is required!"),
                          actions: [
                            okButton,
                          ],
                        );
                        showDialog(
                            context: context,
                            builder: (BuildContext context) {
                              return alert;
                            });
                      }
                    },
                    color: Colors.blue,
                  ),
                ],
              ),
            ),
          ),
          
          Expanded(
            child: reviewWidget(),
          )
        ],
      ),
    );
  }

  Widget reviewWidget() {
    return FutureBuilder<List<TextReview>>(
        future: getReview(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<TextReview>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                scrollDirection: Axis.vertical,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => reviewViewWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<TextReview>> getReview(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'HairSalonId': req.hairSalonId.toString()};

    var review = await APIService.get('TextReview', queryParams);
    return review!.map((i) => TextReview.fromJson(i)).toList();
  }

  Widget reviewViewWidget(review) => Container(
        height: 190,
        margin: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(16),
          color: Colors.blue[200],
          boxShadow: [
            BoxShadow(
              color: Colors.grey,
              blurRadius: 10.0,
              spreadRadius: 1.0,
              offset: Offset(4.0, 4.0),
            ),
          ],
        ),
        child: Row(
          children: [
            Container(
              width: 100,
              child: CircleAvatar(
                radius: 25.0,
                backgroundColor: Colors.red,
                child: SvgPicture.asset(
                  assetName,
                  color: Colors.white,
                  width: 30.0,
                ),
              ),
            ),
            SizedBox(
              width: 6,
            ),
            Flexible(
              child: Column(
                children: [
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Flexible(
                        child: Text(
                          review.clientName,
                          maxLines: 1,
                          overflow: TextOverflow.ellipsis,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 14,
                          ),
                        ),
                      ),
                      Material(
                        color: Colors.transparent,
                        child: Container(
                          height: 50,
                          width: 50,
                          child: Icon(
                            Icons.reviews,
                            color: Colors.red,
                            size: 22,
                          ),
                        ),
                      ),
                    ],
                  ),
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.start,
                      children: [
                        Text(
                          review.text,
                          overflow: TextOverflow.ellipsis,
                          maxLines: 4,
                          style: GoogleFonts.nunito(
                              color: Colors.black, fontWeight: FontWeight.bold),
                        )
                      ],
                    ),
                  ),
                  SizedBox(
                    height: 15,
                  ),
                  Row(
                    children: [
                      Text(
                        "",
                      ),
                      Spacer(),
                      Padding(
                        padding: const EdgeInsets.only(right: 12),
                        child: RatingBar.builder(
                          itemSize: 15,
                          initialRating: 3.0,
                          minRating: 1,
                          direction: Axis.horizontal,
                          allowHalfRating: true,
                          itemCount: 5,
                          itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
                          itemBuilder: (context, _) => Icon(
                            Icons.star,
                            color: Colors.amber,
                          ),
                          onRatingUpdate: (rating) {},
                        ),
                      )
                    ],
                  )
                ],
              ),
            ),
          ],
        ),
      );
}
