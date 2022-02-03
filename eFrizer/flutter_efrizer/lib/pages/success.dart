import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/pages/home_page.dart';
import 'package:flutter_login/pages/setting_page.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/emptySection.dart';
import 'package:flutter_login/widget/subTitle.dart';
import 'package:provider/provider.dart';

import 'home_page_2.dart';

class Success extends StatefulWidget {
  final ApplicationUser user;
  
  const Success(this.user , { Key? key }) : super(key: key);

  @override
  _SuccessState createState() => _SuccessState(user);
}

class _SuccessState extends State<Success> {
  final ApplicationUser user;

  _SuccessState(this.user);

  var success;
  late ApplicationUser userResult;
  @override
  void initState() {
    super.initState();
    success = 'assets/success.gif';

  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Scaffold(
      backgroundColor: Colors.white,
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          EmptySection(success, 'Successful !!'),
          SubTitle('Your payment was done successfully'),
          Container(
          width: MediaQuery.of(context).size.width,
          margin: EdgeInsets.symmetric(vertical: 24.0),
          padding: EdgeInsets.symmetric(horizontal: 24.0),
          child: FlatButton(
          padding: EdgeInsets.symmetric(vertical: 10.0),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(30.0)),
          color: Colors.blue,
          textColor: Color(0xFFFFFFFF),
          highlightColor: Colors.transparent,
          onPressed: (){
            
             Navigator.of(context).push(
              MaterialPageRoute(
                builder: (context) => HomePage2(user),
              ),
            );
          },
          child: Text("Ok".toUpperCase()),
        ),),
        ],
      ),
    );
  }
}