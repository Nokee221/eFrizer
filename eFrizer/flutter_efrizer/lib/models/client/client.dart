import 'package:flutter/material.dart';
import '../application_user/application_user.dart';

class Client extends ApplicationUser {
  Client(
      {required int applicationUserId,
      required dynamic username,
      required String surname,
      required String name,
      required String description,
      required List<dynamic> roles})
      : super(
            applicationUserId: applicationUserId,
            username: username,
            surname: surname,
            description: description,
            name: name,
            roles: roles);

  factory Client.fromJson(Map<String, dynamic> json) {
    return Client(
        applicationUserId: int.parse(json["applicationUserId"].toString()),
        name: json["name"],
        surname: json["surname"],
        description: json["description"],
        username: json["username"],
        roles: json["roles"] as List<dynamic>);
  }
}
