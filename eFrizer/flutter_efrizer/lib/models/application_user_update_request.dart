import 'package:flutter/material.dart';

class ApplicationUserUpdateRequest{
  late final String username;
  late final String name;
  late final String surname;
  late final String description;

  ApplicationUserUpdateRequest({
    required this.name,
    required this.description,
    required this.surname,
    required this.username
  });
}

