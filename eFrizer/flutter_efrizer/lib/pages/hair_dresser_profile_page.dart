import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/login.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/pages/edit_profile_page.dart';
import 'package:flutter_login/pages/user_history.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/widget/button_widget.dart';
import 'package:flutter_login/widget/profile_widget.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:list_tile_switch/list_tile_switch.dart';
import 'package:provider/provider.dart';

class HairDresserProfilePage extends StatefulWidget {
  final ApplicationUser user;
  const HairDresserProfilePage(this.user, {Key? key}) : super(key: key);

  @override
  _HairDresserProfilePageState createState() =>
      _HairDresserProfilePageState(user);
}

class _HairDresserProfilePageState extends State<HairDresserProfilePage> {
  final ApplicationUser user;
  final icon = CupertinoIcons.moon_stars;

  _HairDresserProfilePageState(this.user);

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Scaffold(
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Profile",
          style: GoogleFonts.pacifico(
              color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: ListView(
        physics: BouncingScrollPhysics(),
        children: [
          const SizedBox(height: 24),
          buildName(user),
          const SizedBox(height: 24),
          buildAbout(user),
          const SizedBox(height: 8),
          Divider(
            thickness: 1,
            color: Colors.grey,
          ),
          ListTileSwitch(
            value: themeChange.darkTheme,
            leading: Icon(Icons.mood_rounded),
            onChanged: (value) {
              setState(() {
                themeChange.darkTheme = value;
              });
            },
            visualDensity: VisualDensity.comfortable,
            switchType: SwitchType.cupertino,
            switchActiveColor: Colors.indigo,
            title: Text('Dark theme'),
          ),
          userListTile('Logout', ' ', 4, context),
        ],
      ),
    );
  }

  Widget userListTile(
      String title, String subTitles, int index, BuildContext context) {
    return Material(
      color: Colors.transparent,
      child: InkWell(
        splashColor: Theme.of(context).splashColor,
        child: ListTile(
          onTap: () {
            Navigator.of(context).pushAndRemoveUntil(
              MaterialPageRoute(
                builder: (BuildContext context) => LoginPage(),
              ),
              (route) => false,
            );
          },
          title: Text(title),
          subtitle: Text(subTitles),
          leading: Icon(
            Icons.exit_to_app_rounded,
          ),
        ),
      ),
    );
  }

  Widget buildName(user) => Column(
        children: [
          Text(
            user.username,
            style: TextStyle(fontWeight: FontWeight.bold, fontSize: 24),
          ),
          const SizedBox(height: 4),
          Text(
            user.name,
            style: TextStyle(
              color: Colors.grey,
            ),
          ),
          Text(
            user.surname,
            style: TextStyle(
              color: Colors.grey,
            ),
          )
        ],
      );

  Widget buildAbout(user) => Container(
        padding: EdgeInsets.symmetric(horizontal: 48),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              "About",
              style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 16),
            Text(
              //"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
              user.description == null ? " " : user.description,
              style: TextStyle(fontSize: 16, height: 1.4),
            )
          ],
        ),
      );
}
