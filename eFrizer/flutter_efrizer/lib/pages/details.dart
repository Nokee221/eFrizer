import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/hairdress.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/custom_list_title.dart';
import 'package:flutter_svg/svg.dart';

import 'calendar_page.dart';

class Details extends StatefulWidget {
  final HairSalon hairSalon;
  const Details(this.hairSalon, { Key? key }) : super(key: key);

  @override
  _DetailsState createState() => _DetailsState(hairSalon);
}

class _DetailsState extends State<Details> {
  final HairSalon hairsalon;
  final icon = CupertinoIcons.moon_stars;
  final String assetName = 'assets/hairdresser.svg';

  _DetailsState(this.hairsalon);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
         leading: BackButton(color: Colors.blue),
        backgroundColor: Colors.transparent,
        elevation: 0,
        actions: [
      IconButton(
        icon: Icon(icon),
        color: Colors.blue,
        onPressed: () {},
      ),
      ],
      ),
      body: ListView(
        children: <Widget>[
          SizedBox(height: 10.0),
          Container(
            padding: EdgeInsets.only(left: 20),
            height: 250.0,
            child: ListView(
               padding: EdgeInsets.only(right: 10.0),
               children: <Widget>[
                 Padding(
                   padding: EdgeInsets.only(right: 10.0),
                   child: ClipRRect(
                     borderRadius: BorderRadius.circular(10.0),
                     child: Ink.image(
                  image: NetworkImage(
                    'https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg',
                  ),
                  height: 240,
                  fit: BoxFit.cover,
                ),
                   ),
                 )
               ],
            ),
          ),
          SizedBox(height: 20),
          ListView(
            padding: EdgeInsets.symmetric(horizontal: 20),
            physics: NeverScrollableScrollPhysics(),
            primary: false,
            shrinkWrap: true,
            children: <Widget>[
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: <Widget>[
                  Container(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      hairsalon.Name,
                      style: TextStyle(
                        fontWeight: FontWeight.w700,
                        fontSize: 20,
                      ),
                      maxLines: 2,
                      textAlign: TextAlign.left,
                    ),
                  ),
                  IconButton(
                    icon: Icon(
                      Icons.bookmark,
                    ),
                    onPressed: (){},
                  )
                ],
              ),
              Row(
                children: <Widget>[
                  Icon(
                    Icons.location_on,
                    size: 14,
                    color: Colors.blueGrey[300],
                  ),
                  SizedBox(width: 3),
                  Container(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      hairsalon.Address,
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        fontSize: 13,
                        color: Colors.blueGrey[300],
                      ),
                      maxLines: 1,
                      textAlign: TextAlign.center,
                    ),
                  ),
                ],
              ),
              SizedBox(height: 40),
              Container(
                alignment: Alignment.centerLeft,
                child: Text(
                  "Details",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 16,
                  ),
                  maxLines: 1,
                  textAlign: TextAlign.left,
                ),
              ),
              SizedBox(height: 10),
              Container(
                alignment: Alignment.centerLeft,
                child: Text(
                  hairsalon.Description,
                  style: TextStyle(
                    fontWeight: FontWeight.normal,
                    fontSize: 15.0,
                  ),
                  textAlign: TextAlign.left,
                ),
              ),
              SizedBox(height: 30.0),
              CustomListTitle(title: "Pick your hairdresser"),
              SizedBox(height: 15.0),
              Container(
                width: double.infinity,
                height: 90,
                child: listHairDresser(),
              )
            ],
          )
        ],
      ),
    );
  }

   Widget listHairDresser() {
    return FutureBuilder<List<HairDresser>>(
        future: GetHairDressers(),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairDresser>> snapshot) {
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
                children: snapshot.data!.map((e) => HairDresserWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairDresser>> GetHairDressers() async {
    

    var hairdresser = await APIService.Get('HairDresser', null);
    if(hairdresser != null){

      return hairdresser.map((i) => HairDresser.fromJson(i)).toList();
    }
    else{
      return List.empty();
    }

  }

  Widget HairDresserWidget(hairdresser) => Container(
    width: 70.0,
      margin: EdgeInsets.only(left: 10.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          InkWell(
            onTap: (){
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context) => CalendarPage()),
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
                width: 30.0,
                
              ),
              ),
              SizedBox(height: 7),
              Text(hairdresser.name, style: TextStyle(fontSize: 10, fontWeight: FontWeight.bold),),

              ],
            )
          )
          
        ],
      ),
  );
}