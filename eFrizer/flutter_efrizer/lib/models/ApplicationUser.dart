import 'package:flutter/material.dart';
import 'dart:convert';

class ApplicationUser{
  final String username;



  ApplicationUser({
    required this.username,

  });

  void SetParameter(String Username, String Password)
  {
  
  }

  factory ApplicationUser.fromJson(Map<String, dynamic> json){

        return ApplicationUser(
            username: json["username"],
        );
    }

    Map<String, dynamic> toJson() => {
        "username": username,
      
        
    };


}
