import 'package:flutter/material.dart';
import 'package:flutter_login/models/hairsalon_type.dart';

class CategoryPage extends StatefulWidget {
  final HairSalonType hairSalonType;


  const CategoryPage(this.hairSalonType , { Key? key }) : super(key: key);

  @override
  _CategoryPageState createState() => _CategoryPageState();
}

class _CategoryPageState extends State<CategoryPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      
    );
  }
}