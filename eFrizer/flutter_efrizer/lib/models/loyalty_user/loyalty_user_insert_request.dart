class LoyatlyBonusUserInsertRequest{
  final int hairSalonServiceLoyaltyBonusId;
  final int clientId;

  LoyatlyBonusUserInsertRequest({
    required this.hairSalonServiceLoyaltyBonusId,
    required this.clientId
  });

  factory LoyatlyBonusUserInsertRequest.fromJson(Map<String, dynamic> json) {
    return LoyatlyBonusUserInsertRequest(
      clientId: int.parse(json['clientId'].toString()),
      hairSalonServiceLoyaltyBonusId: int.parse(json['hairSalonServiceLoyaltyBonusId'].toString())
    );
  }

  Map<String, dynamic> toJson() => {
        "hairSalonServiceLoyaltyBonusId": hairSalonServiceLoyaltyBonusId,
        "clientId": clientId,
      };
}