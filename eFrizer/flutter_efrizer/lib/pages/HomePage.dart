import 'package:curved_navigation_bar/curved_navigation_bar.dart';
import 'package:flutter/material.dart';
import 'HomePage2.dart';
import 'SearchPage.dart';
import 'FavoritePage.dart';
import 'ProfilePage.dart';
import 'SettingPage.dart';


class HomePage extends StatefulWidget {
  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  int index = 0;

  final screens = [
    HomePage2(),
    SearchPage(),
    FavoritePage(),
    SettingPage(),
    //ProfilePage(),
  ];
  
  
  @override
  Widget build(BuildContext context) {
    final items = <Widget>[
      Icon(Icons.home, size: 30),
      Icon(Icons.search, size: 30),
      Icon(Icons.favorite, size: 30),
      Icon(Icons.settings, size: 30),
      Icon(Icons.person, size: 30),
    ];
    

    return Scaffold(
      backgroundColor: Colors.blue,
      body: screens[index],
      bottomNavigationBar: CurvedNavigationBar(
        height: 60,
        index: index,
        items: items,
        onTap: (index) => setState(() => this.index = index),
      ),
    );
  }
}