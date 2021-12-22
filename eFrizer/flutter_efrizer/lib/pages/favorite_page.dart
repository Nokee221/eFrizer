import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/custom_list_title.dart';
import 'package:google_fonts/google_fonts.dart';

import 'details.dart';

class FavoritePage extends StatefulWidget {
  final ApplicationUser user;
  const FavoritePage(this.user, { Key? key }) : super(key: key);

  @override
  _FavoritePageState createState() => _FavoritePageState(user);
}

class _FavoritePageState extends State<FavoritePage> {
  final ApplicationUser _user;
  final icon = CupertinoIcons.moon_stars;

  _FavoritePageState(this._user);

  var request = null;
  void initState() {
    super.initState();
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        child: SingleChildScrollView(
          child: Column(
            children: [
              ClipPath(
                clipper: OvalBottomBorderClipper(),
                child: Container(
                  width: double.infinity,
                  height: 200.0,
                  padding: EdgeInsets.only(bottom: 50.0),
                  decoration: const BoxDecoration(
                    color: Color(0xFFFFAD03),
                    image: DecorationImage(
                      image: NetworkImage('https://www.teahub.io/photos/full/220-2208960_dark-blue-lines-4k-material-design-creative-geometric.jpg'),
                      fit:BoxFit.cover,
                    ),
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      AppBar(
                        leading: BackButton(color: Colors.white),
                        backgroundColor: Colors.transparent,
                        elevation: 0,
                        actions: [
                          IconButton(
                            icon: Icon(icon),
                            color: Colors.white,
                            onPressed: (){},
                          )
                        ],
                      ),
                      //const Spacer(),
                      SizedBox(height: 29),
                      Padding(
                        padding: const EdgeInsets.only(left: 18.0),
                        child: Text(
                          "Hairsalon just for you",
                          style: GoogleFonts.nunito(
                            color: Colors.white,
                            fontSize: 29.0,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
              SizedBox(height: 25.0),
              CustomListTitle(title: "Best salons",),
              Container(
                width: double.infinity,
                height: double.maxFinite,
                child: recommendList(),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget recommendList() {
    return FutureBuilder<List<HairSalon>>(
        future:getHairSalon(),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairSalon>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
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
                children: snapshot.data!.map((e) => HairSalonWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairSalon>> getHairSalon() async {
    var hairsalon = await APIService.recommenderGet('Recommend', _user.applicationUserId.toString());
    if(hairsalon != null){

      return hairsalon.map((i) => HairSalon.fromJson(i)).toList();
    }
    else{
      return List.empty();
    }
    
  }

  Widget HairSalonWidget(hairsalon) => Padding(
    padding: const EdgeInsets.all(15),
    child: InkWell(
      child: Card(
        color: Colors.blueGrey,
        clipBehavior: Clip.antiAlias,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(10),
        ),
        child: Column(
          children: [
            Stack(
              children: [
                Ink.image(
                  image: NetworkImage('https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg'),
                  height: 100,
                  fit: BoxFit.cover,
                ),
                Positioned(
                  bottom: 16,
                  right: 16,
                  left: 16,
                  child: Column(
                    children: [
                      Text(
                      hairsalon.Name,
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                        fontSize: 20,
                      ),
                      ),
                      Text(
                      hairsalon.Address,
                      style: const TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                        fontSize: 10,
                      ),
                      ),
                    ],
                  )
                )
              ],
            )
          ],
        ),
      ),
      onTap: (){
        Navigator.of(context).push(
              MaterialPageRoute(builder: (context) => Details(hairsalon)),
            );
      },
    ),
  );
 
}