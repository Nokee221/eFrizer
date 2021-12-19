import 'package:flutter/material.dart';
import 'package:flutter_login/pages/setting_page.dart';
import 'package:flutter_login/widget/emptySection.dart';
import 'package:flutter_login/widget/subTitle.dart';

class Success extends StatefulWidget {
  
  const Success({ Key? key }) : super(key: key);

  @override
  _SuccessState createState() => _SuccessState();
}

class _SuccessState extends State<Success> {
  var success;

  @override
  void initState() {
    super.initState();
    success = 'assets/success.gif';
  }

  @override
  Widget build(BuildContext context) {
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
                builder: (context) => SettingPage(),
              ),);
          },
          child: Text("Ok".toUpperCase()),
        ),),
        ],
      ),
    );
  }
}