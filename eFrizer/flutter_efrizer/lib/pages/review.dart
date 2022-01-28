import 'package:flutter/material.dart';
import 'package:flutter_login/models/hairsalon/HairSalon.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';

class ReviewPage extends StatefulWidget {
  final HairSalon hairSalon;
  const ReviewPage(this.hairSalon, {Key? key}) : super(key: key);

  @override
  _ReviewPageState createState() => _ReviewPageState(hairSalon);
}

class _ReviewPageState extends State<ReviewPage> {
  final HairSalon hairSalon;

  _ReviewPageState(this.hairSalon);

  final String assetName = 'assets/hairdresser.svg';

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
      body: Container(
        height: 120,
        margin: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(16),
          color: Colors.blue[200],
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
                          "Client Name",
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
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children: [
                      Text(
                        "Text Review",
                      )
                    ],
                  ),
                  SizedBox(
                    height: 20,
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
                          onRatingUpdate: (rating){

                          },
                        ),
                      )
                    ],
                  )
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
