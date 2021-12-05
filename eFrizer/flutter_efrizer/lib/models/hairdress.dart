import 'package:flutter/material.dart';
import 'application_user.dart';

class HairDresser extends ApplicationUser{
  HairDresser({
    required int applicationUserId,
    required dynamic username,
    required String surname, 
    required String name,
    required String description,
  }) : super(applicationUserId: applicationUserId, username: username , surname: surname, description: description, name: name);

  factory HairDresser.fromJson(Map<String, dynamic> json) {
    return HairDresser(
      applicationUserId: int.parse(json["applicationUserId"].toString()),
      name: json["name"],
      surname: json["surname"],
      description: json["description"],
      username: json["username"],
    );
  }
}