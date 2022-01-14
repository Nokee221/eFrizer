class ApplicationUser {
  final int applicationUserId;
  final String? name;
  final String? surname;
  final String? description;
  final String? username;
  final List<dynamic> roles;

  ApplicationUser(
      {required this.applicationUserId,
      this.name,
      this.surname,
      required this.description,
      required this.username,
      required this.roles});

  void SetParameter(String Username, String Password) {}

  factory ApplicationUser.fromJson(Map<String, dynamic> json) {
    return ApplicationUser(
        applicationUserId: int.parse(json["applicationUserId"].toString()),
        name: json["name"],
        surname: json["surname"],
        description: json["description"],
        username: json["username"],
        roles: json["applicationUserRoles"] as List<dynamic>);
  }

  Map<String, dynamic> toJson() => {
        "username": username,
        "name": name,
        "surname": surname,
        "description": description,
      };

  Map<String, dynamic> toJsonWithId() => {
        "applicationUserId": applicationUserId,
        "username": username,
        "name": name,
        "surname": surname,
        "description": description,
        "roles": roles
      };
}
