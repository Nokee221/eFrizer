import 'dart:ui';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/hairsalon_type.dart';
import 'package:flutter_login/pages/details.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/custom_list_title.dart';
import 'package:flutter_svg/flutter_svg.dart';


class SearchPage extends StatefulWidget {
  const SearchPage({ Key? key }) : super(key: key);

  @override
  _SearchPageState createState() => _SearchPageState();
}

class _SearchPageState extends State<SearchPage> {
  final icon = CupertinoIcons.moon_stars;
  final String assetName = 'assets/saloon.svg';
 

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
             SizedBox(height: 15.0),
             Container(
               width: double.infinity,
               height: 90.0,
               child: listWidget()
             ),
             SizedBox(height: 5.0),
             Container(
               width: double.infinity,
               height: 400.0,
               child: listHairSalon(),
             )
            ],
          ),
        ),
      ),
    );
  }

  Widget listWidget() {
    return FutureBuilder<List<HairSalonType>>(
        future: GetHairSalonType(),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairSalonType>> snapshot) {
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
                scrollDirection: Axis.horizontal,
                physics: ScrollPhysics(),
                children: snapshot.data!.map((e) => HairSalonTypeWidget(e)).toList(),
              );
            }
          }
        });
  }

  Widget listHairSalon() {
    return FutureBuilder<List<HairSalon>>(
        future: GetHairSalon(),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairSalon>> snapshot) {
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
                children: snapshot.data!.map((e) => HairSalonWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairSalonType>> GetHairSalonType() async {
    

    var hairsalontype = await APIService.Get('HairSalonType', null);
    if(hairsalontype != null){

      return hairsalontype.map((i) => HairSalonType.fromJson(i)).toList();
    }
    else{
      return List.empty();
    }

  }

  Future<List<HairSalon>> GetHairSalon() async {
    

    var hairsalon = await APIService.Get('HairSalon', null);
    if(hairsalon != null){

      return hairsalon.map((i) => HairSalon.fromJson(i)).toList();
    }
    else{
      return List.empty();
    }

  }

  Widget HairSalonTypeWidget(hairsalontype) => Container(
    width: 70.0,
      margin: EdgeInsets.only(left: 10.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          InkWell(
            onTap: (){
              Navigator.of(context).push(
                          MaterialPageRoute(builder: (context) => SearchPage()),
                        );
            },
            child: Column(
              children: [

              CircleAvatar(
              radius: 25.0,
              backgroundColor: Colors.blue,
              child: SvgPicture.asset(
                assetName,
                color: Colors.white,
                width: 15.0,
                
              ),
              ),
              Text(hairsalontype.name),
          
              ],
            )
          )
          
        ],
      ),
  );

  Widget HairSalonWidget(hairsalon) => Padding(
    padding: const EdgeInsets.all(15),
    child: InkWell(
      child: Card(
        color: Colors.blueGrey,
        clipBehavior: Clip.antiAlias,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(24),
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
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                        fontSize: 20,
                      ),
                      ),
                      Text(
                      hairsalon.Address,
                      style: TextStyle(
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