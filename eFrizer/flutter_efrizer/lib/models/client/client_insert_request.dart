class ClientInsertRequest {
  late final String name;
  late final String surname;
  late final String username;
  late final String password;
  late final String passwordConfirmation;
  late final String description;
  late final bool Status;

  ClientInsertRequest(
      {required this.name,
      required this.password,
      required this.passwordConfirmation,
      required this.surname,
      required this.username});

  Map<String, dynamic> toJson() => {
        "name": name,
        "surname": surname,
        "username": username,
        "password": password,
        "passwordConfirmation": passwordConfirmation
      };
}
