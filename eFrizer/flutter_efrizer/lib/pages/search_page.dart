import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/widget/custom_list_title.dart';



class SearchPage extends StatefulWidget {
  const SearchPage({ Key? key }) : super(key: key);

  @override
  _SearchPageState createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
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
                  height: 250.0,
                  padding: EdgeInsets.only(bottom: 50.0),
                  decoration: BoxDecoration(
                    color: Color(0xFFFFAD03),
                    image: DecorationImage(
                      image: NetworkImage('https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg'),
                      fit: BoxFit.cover,
                    ),
                  ),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      AppBar(
                        leading: BackButton(color: Colors.blue),
                        backgroundColor: Colors.transparent,
                        elevation: 0,
                        actions: [
                          IconButton(
                            icon: Icon(icon),
                            color: Colors.white,
                            onPressed: () {},
                      ),
                    ],
                  ),
                  Spacer(),
                  Padding(
                    padding: const EdgeInsets.only(left: 18.0),
                    child: Text(
                      "Find a hairsalon for you",
                      style: TextStyle(
                        color: Colors.white,
                        fontWeight: FontWeight.bold,
                        fontSize: 18.0,
                      ),
                    ),
                  ),
                  SizedBox(height: 15.0),
                  Container(
                    width: double.infinity,
                    height: 50.0,
                    margin: EdgeInsets.symmetric(horizontal: 18.0),
                    padding: EdgeInsets.symmetric(horizontal: 15.0),
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(12.0),
                      color: Colors.white.withOpacity(.9),
                    ),
                    child: TextField(
                      cursorColor: Color(0xFF4C4C4C),
                      decoration: InputDecoration(
                        hintText: "Search Saloon, Spa and Barber",
                        hintStyle: TextStyle(color: Color(0xFFACACAC), fontSize: 12.0),
                        border: InputBorder.none,
                        icon: Icon(
                          Icons.search,
                          color: Color(0xFFACACAC),
                        ),
                      ),
                    ),
                  ),
                  ],
                ),
              ),
             ),
             SizedBox(height: 25.0),
             CustomListTitle(title: "Top Categories"),
             SizedBox(height: 25.0),
             Container(
               width: double.infinity,
               height: 100.0,
               child: ListView(
                 //serviceWidget(),
               ),
             )
            ],
          ),
        ),
      ),
    );
  }
}