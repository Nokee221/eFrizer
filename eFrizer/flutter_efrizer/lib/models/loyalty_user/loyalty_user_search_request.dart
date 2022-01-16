
class LoyaltyBonusUserSearchRequest{
  int clientId;
  int? hairSalonServiceLoyaltyBonusId;
  int? hairSalonServiceId;

  LoyaltyBonusUserSearchRequest({
    required this.clientId,
    this.hairSalonServiceLoyaltyBonusId,
    this.hairSalonServiceId,
  });

  factory LoyaltyBonusUserSearchRequest.fromJson(Map<String, dynamic> json) {
    return LoyaltyBonusUserSearchRequest(
      clientId: int.parse(json['clientId'].toString()),
      hairSalonServiceLoyaltyBonusId: int.parse(json['loyaltyBonusId'].toString()),
      hairSalonServiceId: int.parse(json['hairSalonServiceId'].toString()),

    );
  }
}