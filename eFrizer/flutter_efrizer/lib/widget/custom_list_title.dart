import 'package:flutter/material.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:provider/provider.dart';

class CustomListTitle extends StatelessWidget {
  final String? title;
  
  CustomListTitle({this.title});

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 18.0),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            title!,
            style: TextStyle(
              color: themeChange.darkTheme ? Colors.white : Colors.black,
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