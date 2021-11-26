import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/widget/appbar_widget.dart';
import 'package:flutter_login/widget/profile_widget.dart';

class ProfilePage extends StatefulWidget {
  final ApplicationUser user;
  const ProfilePage(this.user, {Key? key}) : super(key: key);

  @override
  _ProfilePageState createState() => _ProfilePageState(user);
}

class _ProfilePageState extends State<ProfilePage> {
  final ApplicationUser user;

  _ProfilePageState(this.user);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Text(user.username),
    );
  }
}
