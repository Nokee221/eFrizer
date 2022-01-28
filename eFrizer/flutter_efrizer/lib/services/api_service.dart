import 'dart:convert';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/client/client.dart';
import 'package:flutter_login/models/client/client_insert_request.dart';
import 'package:flutter_login/models/hairdresser/hair_dresser.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user.dart';
import 'package:http/http.dart' as http;
import 'dart:io';

class APIService {
  static String? username;
  static String? password;
  //deployed apI: "http://efrizer.germanywestcentral.azurecontainer.io:5000/"
  static String apiUrl = "http://10.0.2.2:5000/";

  String? route;

  APIService({this.route});

  void SetParameter(String Username, String Password) {
    username = Username;
    password = Password;
  }

  static Future<List<dynamic>?> get(String route, dynamic object) async {
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
      var result = JsonDecoder().convert(response.body) as List;
      return result;
    }
    return null;
  }

  static Future<LoyaltyUser?> getLoyalty(String route, dynamic object) async {
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
      var res = json.decode(response.body);
      var data;
      if (res.length != 0) {
        data = LoyaltyUser.fromJson(res[0]);
      } else {
        data = null;
      }

      return data;
    }
    return null;
  }

  static Future<LoyaltyBonus?> getLoyaltyBonus(
      String route, dynamic object) async {
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
     
      var res = json.decode(response.body);
      var data;
      if(res.length != 0)
      {

        data = LoyaltyBonus.fromJson(res[0]);
      }
      else{
        data = null;
      }

      return data;
    }
    return null;
  }

  static Future<dynamic> getAverage(String route, dynamic object) async {
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
      return response.body;
    }

    return 0.0;
  }

  static Future<dynamic> getById(String route, String id) async {
    String baseUrl = apiUrl + route + "/" + id;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body);
    }
    return null;
  }

  static Future<List<dynamic>?> getHairSalon(String route) async {
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

  static Future<ApplicationUser?> login(
      String route, String username, String password) async {
    final String baseUrl =
        apiUrl + route + "?Username=" + username + "&Password=" + password;
    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    try {
      final response = await http.get(
        Uri.parse(baseUrl),
        headers: {HttpHeaders.authorizationHeader: basicAuth},
      );

      if (response.statusCode == 200) {
        var res = json.decode(response.body);
        var initialData = ApplicationUser.fromJson(res);
        dynamic data;
        if (initialData.roles[0]["role"]["name"] == "Client") {
          data = Client.fromJson(initialData.toJsonWithId());
        } else if (initialData.roles[0]["role"]["name"] == "HairDresser") {
          data = HairDresser.fromJson(initialData.toJsonWithId());
        }
        return data;
      } else if (response.statusCode == 400) {
        List<dynamic> roles = [""];
        return ApplicationUser(
            applicationUserId: 0,
            description: "description",
            username: "username",
            roles: roles);
      }
    } on Exception catch (e) {
      return null;
    }
  }

  static Future<ApplicationUser?> register(
      String route, ClientInsertRequest req) async {
    final String baseUrl = apiUrl + route;
    final response = await http.post(Uri.parse(baseUrl),
        body: jsonEncode(req.toJson()),
        headers: <String, String>{'Content-Type': 'application/json'});

    if (response.statusCode == 200) {
      Client data = Client.fromJsonLimited(json.decode(response.body));
      return data;
    } else {
      return null;
    }
  }

  static Future<ApplicationUser?> update(
      String route, String id, dynamic updateRequest) async {
    final String baseUrl = apiUrl + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    print(jsonEncode(updateRequest));
    final response = await http.put(Uri.parse(baseUrl),
        headers: <String, String>{
          'Content-Type': 'application/json',
          HttpHeaders.authorizationHeader: basicAuth
        },
        body: jsonEncode(updateRequest));

    print(response.body);
    print(Uri.parse(baseUrl));

    if (response.statusCode == 200) {
      var data = ApplicationUser.fromJson(jsonDecode(response.body));

      return data;
    }

    return null;
  }

  static Future<LoyaltyUser?> updateLoyalty(
      String route, String id, dynamic updateRequest) async {
    final String baseUrl = apiUrl + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    print(jsonEncode(updateRequest));
    final response = await http.put(Uri.parse(baseUrl),
        headers: <String, String>{
          'Content-Type': 'application/json',
          HttpHeaders.authorizationHeader: basicAuth
        },
        body: jsonEncode(updateRequest));

    print(response.body);
    print(Uri.parse(baseUrl));

    if (response.statusCode == 200) {
      var data = LoyaltyUser.fromJson(jsonDecode(response.body));

      return data;
    }

    return null;
  }

  static Future<dynamic?> post(String route, dynamic request) async {
    final String baseUrl = apiUrl + route;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.post(Uri.parse(baseUrl),
        headers: <String, String>{
          'Content-Type': 'application/json',
          HttpHeaders.authorizationHeader: basicAuth
        },
        body: jsonEncode(request));

    print(Uri.parse(baseUrl));

    if (response.statusCode == 200) {
      var data = JsonDecoder().convert(response.body);

      return data;
    }

    return null;
  }

  static Future<List<dynamic>?> recommenderGet(String route, String id) async {
    final String baseUrl = apiUrl + route + "?clientId=" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));
    final response = await http.get(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      var result = JsonDecoder().convert(response.body) as List;
      return result;
    }
    return null;
  }

  static Future<dynamic?> delete(String route, dynamic id) async {
    String baseUrl = apiUrl + route + "/" + id;

    final String basicAuth =
        'Basic ' + base64Encode(utf8.encode('$username:$password'));

    final response = await http.delete(
      Uri.parse(baseUrl),
      headers: {HttpHeaders.authorizationHeader: basicAuth},
    );

    if (response.statusCode == 200) {
      var data = JsonDecoder().convert(response.body);

      return data;
    }

    return Exception('Failed to delete reservation');
  }
}
