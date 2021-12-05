import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_login/config.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/models/application_user_update_request.dart';
import 'package:http/http.dart' as http;
import 'dart:io';

class APIService {
  static String? username;
  static String? password;
  static String apiUrl = devIp;

  String? route;

  APIService({this.route});

  void SetParameter(String Username, String Password) {
    username = Username;
    password = Password;
  }

  static Future<List<dynamic>?> Get(String route, dynamic object) async {
    String queryString = Uri(queryParameters: object).query;

    String baseUrl = apiUrl + route;
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

    String baseUrl = apiUrl + route;
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

    final String baseUrl =
        apiUrl + route + "?Username=" + username + "&Password=" + password;
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


  static Future<ApplicationUser?> Update(String route, String id , dynamic object) async {
    final String baseUrl = apiUrl + route+"/"+ id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.put(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth, 
                'Content-Type': 'application/x-www-form-urlencoded'},
      body: jsonEncode(object),
      
    );

    if (response.statusCode == 204) {
      var data = ApplicationUser.fromJson(jsonDecode(response.body));

      return data;
    }

    return null;
  }
}
