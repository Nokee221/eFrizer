class ApplicationUser {
  final int? applicationUserId;
  final String? name;
  final String? surname;
  final String? description;
  final String username;
  final String? password;
  final List<String>? roles;

  ApplicationUser(
      {this.applicationUserId,
      this.name,
      this.surname,
      this.description,
      required this.username,
      this.password,
      this.roles});

  void SetParameter(String Username, String Password) {}

  factory ApplicationUser.fromJson(Map<String, dynamic> json) {
    return ApplicationUser(
      applicationUserId: json["applicationUserId"],
      name: json["name"],
      surname: json["surname"],
      description: json["decription"],
      username: json["username"],
      password: json["password"],
    );
  }

  Map<String, dynamic> toJson() => {
        "username": username,
        "password": password,
      };
}

class ApplicationUserSearchRequest {
  String? username;
  String? password;

  ApplicationUserSearchRequest({this.username, this.password});

  Map<String, dynamic> toJson() {
    Map<String, dynamic> map = {
      'username': username?.trim(),
      'password': password?.trim(),
    };

    return map;
  }
}
