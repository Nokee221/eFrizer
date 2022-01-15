import 'package:curved_navigation_bar/curved_navigation_bar.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/pages/hair_dresser_calendar_page.dart';
import 'package:flutter_login/pages/hair_dresser_profile_page.dart';
import 'profile_page.dart';

class HairDresserHomePage extends StatefulWidget {
  final ApplicationUser user;

  const HairDresserHomePage(this.user);

  @override
  _HairDresserHomePageState createState() => _HairDresserHomePageState(user);
}

class _HairDresserHomePageState extends State<HairDresserHomePage> {
  final ApplicationUser user;
  var screens = [];

  _HairDresserHomePageState(this.user) {
    screens = [
      HairDresserCalendarPage(this.user.applicationUserId),
      HairDresserProfilePage(this.user),
    ];
  }

  int index = 0;

  @override
  Widget build(BuildContext context) {
    final items = <Widget>[
      Icon(Icons.home, size: 30),
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
