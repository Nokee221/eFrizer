import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/pages/edit_profile_page.dart';
import 'package:flutter_login/pages/user_history.dart';
import 'package:flutter_login/widget/button_widget.dart';
import 'package:flutter_login/widget/numbers_widget.dart';
import 'package:flutter_login/widget/profile_widget.dart';
import 'package:google_fonts/google_fonts.dart';

class ProfilePage extends StatefulWidget {
  final ApplicationUser user;
  const ProfilePage(this.user, {Key? key}) : super(key: key);

  @override
  _ProfilePageState createState() => _ProfilePageState(user);
}

class _ProfilePageState extends State<ProfilePage> {
  final ApplicationUser user;
  final icon = CupertinoIcons.moon_stars;

  _ProfilePageState(this.user);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text("Profile", style: GoogleFonts.pacifico(color: Colors.black),),
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
        physics: BouncingScrollPhysics(),
        children: [
          ProfileWidget(
            imagePath: 'https://media.istockphoto.com/photos/millennial-male-team-leader-organize-virtual-workshop-with-employees-picture-id1300972574?b=1&k=20&m=1300972574&s=170667a&w=0&h=2nBGC7tr0kWIU8zRQ3dMg-C5JLo9H2sNUuDjQ5mlYfo=',
            onClicked: () {
              Navigator.of(context).push(
                MaterialPageRoute(builder: (context) => EditeProfilePage(user)),
              );
            },
          ),
          const SizedBox(height: 24),
          buildName(user),
          const SizedBox(height: 24),
          Center(child: buildUpgradeButtton()),
          const SizedBox(height: 24),
          NumbersWidget(),
          const SizedBox(height: 48),
          buildAbout(user),
        ],
      ),
    );
  }

  Widget buildName(user) => Column(
    children: [
      Text(
        user.username,
        style: TextStyle(
          fontWeight: FontWeight.bold,
          fontSize: 24
        ),
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

  Widget buildUpgradeButtton() => ButtonWidget(text: 'VIEW HISTORY ', onClicked: (){
    Navigator.of(context).push(
                MaterialPageRoute(builder: (context) => History(user)),
              );
  });

  Widget buildAbout(user) => Container(
    padding: EdgeInsets.symmetric(horizontal: 48),
    child: Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          "About",
          style: TextStyle(
            fontSize: 24,
            fontWeight: FontWeight.bold
          ),
        ),
        const SizedBox(height: 16),
        Text(
          //"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
          user.description,
          style: TextStyle(fontSize: 16, height: 1.4),
        )
      ],
    ),
  );

}

