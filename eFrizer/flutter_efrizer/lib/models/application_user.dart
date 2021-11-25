import 'package:flutter/material.dart';
import 'dart:convert';

class ApplicationUser{
  final String? username;
  final String? password;


  ApplicationUser({
    this.username,
    this.password
  });

  void SetParameter(String Username, String Password)
  {
  
  }

  factory ApplicationUser.fromJson(Map<String, dynamic> json){

        return ApplicationUser(
            username: json["username"],
            password: json["password"],
        );
    }

    Map<String, dynamic> toJson() => {
        "username": username,
        "password": password,
        
    };


}

class ApplicationUserSearchRequest{
  String? username;
  String? password;

  ApplicationUserSearchRequest({
    this.username,
    this.password
  });

  Map<String , dynamic> toJson() {
   
   Map<String, dynamic> map ={
      'username': username?.trim(),
      'password': password?.trim(),
    };

    return map;
  }
}