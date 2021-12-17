class LoyaltyBonus {
  final int id;
  final int serviceId;
  final int discount;
  final int activatesOn;
  final int expiresIn;
  final String serviceName;

  LoyaltyBonus(
      {required this.id,
      required this.serviceId,
      required this.discount,
      required this.activatesOn,
      required this.expiresIn,
      required this.serviceName});

  factory LoyaltyBonus.fromJson(Map<String, dynamic> json) {
    return LoyaltyBonus(
        id: int.parse(json["id"].toString()),
        serviceId: json["hairSalonServiceId"],
        discount: json["discount"],
        activatesOn: json["activatesOn"],
        expiresIn: int.parse(json["expiresIn"].toString()),
        serviceName: json["serviceName"]);
  }

  Map<String, dynamic> toJson() => {
        "id": id,
        "serviceId": serviceId,
        "discount": discount,
        "activatesOn": activatesOn,
        "expiresIn": expiresIn,
        "serviceName": serviceName
      };
}
