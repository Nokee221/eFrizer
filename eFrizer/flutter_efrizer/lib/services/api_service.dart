import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:http/http.dart' as http;
import 'dart:io';

class APIService {
  static String? username;
  static String? password;

  String? route;

  APIService({this.route});

  void SetParameter(String Username, String Password) {
    username = Username;
    password = Password;
  }

  static Future<List<dynamic>?> Get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;
    String baseUrl = "http://172.21.160.1:80/" + route;
    if (object != null) {
      baseUrl = baseUrl + '?' + queryString;
    }
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }
  
  static Future<List<dynamic>?> GetHairSalon(String route) async {
    String baseUrl = "http://172.21.160.1:80/" + route;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body) as List;
    }
    return null;
  }

  static Future<ApplicationUser?> Login(
      String route, String username, String password) async {
    final String baseUrl = "http://172.21.160.1:80/" +
        route +
        "?Username=" +
        username +
        "&Password=" +
        password;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      var res = json.decode(response.body);
      var data = ApplicationUser.fromJson(res);

      return data;
    }


    return null;
  }

  static Future<ApplicationUser?> updateUser(String route ,  String username , String name , String surname , String description) async{
    final String baseUrl = "http://172.21.160.1:80/" + route;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.put(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
      body: jsonEncode(<String,String>{
        'username': username,
        'nema': name,
        'surname': surname,
        'descripiton': description,
      }),
    );

    if (response.statusCode == 200) {
      var data = ApplicationUser.fromJson(jsonDecode(response.body));

      return data;
    }


    return null;
  }

  

}