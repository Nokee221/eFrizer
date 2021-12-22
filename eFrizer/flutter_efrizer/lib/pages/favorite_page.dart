import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/widget/custom_list_title.dart';
import 'package:google_fonts/google_fonts.dart';

class FavoritePage extends StatefulWidget {
  const FavoritePage({ Key? key }) : super(key: key);

  @override
  _FavoritePageState createState() => _FavoritePageState();
}

class _FavoritePageState extends State<FavoritePage> {
  final icon = CupertinoIcons.moon_stars;


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
              
            ],
          ),
        ),
      ),
    );
  }
}