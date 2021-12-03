import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';

import 'calendar_page.dart';

class Details extends StatelessWidget {
  final HairSalon hairsalon;
  final icon = CupertinoIcons.moon_stars;


  const Details(this.hairsalon, {Key? key}) : super(key: key);

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
              SizedBox(height: 10.0),
            ],
          )
        ],
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(
          Icons.add,
        ),
        onPressed: (){
          Navigator.of(context).push(
                MaterialPageRoute(builder: (context) => CalendarPage()),
              );
        },
      ),
    );
  }
}