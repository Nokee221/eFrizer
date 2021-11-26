import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';

class Details extends StatelessWidget {
  final HairSalon hairsalon;

  const Details(this.hairsalon, {Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Text(hairsalon.Name),
    );
  }
}