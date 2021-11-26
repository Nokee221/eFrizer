import 'package:curved_navigation_bar/curved_navigation_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user.dart';
import 'home_page_2.dart';
import 'search_page.dart';
import 'favorite_page.dart';
import 'profile_page.dart';
import 'setting_page.dart';

class HomePage extends StatefulWidget {
  final ApplicationUser user;

  const HomePage(this.user);

  @override
  _HomePageState createState() => _HomePageState(user);
}

class _HomePageState extends State<HomePage> {
  final ApplicationUser user;
  var screens = [];

  _HomePageState(this.user) {
    screens = [
      HomePage2(),
      SearchPage(),
      FavoritePage(),
      SettingPage(),
      ProfilePage(this.user),
    ];
  }

  int index = 0;

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
        extendBody: true,
        backgroundColor: Colors.blue,
        body: screens[index],
        bottomNavigationBar: Theme(
          data: Theme.of(context)
              .copyWith(iconTheme: IconThemeData(color: Colors.white)),
          child: CurvedNavigationBar(
            color: Colors.blue,
            backgroundColor: Colors.transparent,
            height: 50,
            index: index,
            items: items,
            onTap: (index) => setState(() => this.index = index),
          ),
        ));
  }
}
