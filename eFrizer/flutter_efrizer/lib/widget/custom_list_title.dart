import 'package:flutter/material.dart';

class CustomListTitle extends StatelessWidget {
  final String? title;
  
  CustomListTitle({this.title});

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 18.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            title!,
            style: TextStyle(
              color: Color(0xFF4C4C4C),
              fontSize: 15.0,
              fontWeight: FontWeight.bold,
            ), 

          ),
          Text(
            "View all",
            style: TextStyle(
              color: Color(0xFFACACAC),
              fontSize: 12.0
            ),
          ),
        ],
      ),
    );
  }
}