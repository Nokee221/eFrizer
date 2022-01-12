
class LoyaltyBonusUserSearchRequest{
  int clientId;
  int loyaltyBonusId;

  LoyaltyBonusUserSearchRequest({
    required this.clientId,
    required this.loyaltyBonusId
  });

  factory LoyaltyBonusUserSearchRequest.fromJson(Map<String, dynamic> json) {
    return LoyaltyBonusUserSearchRequest(
      clientId: int.parse(json['clientId'].toString()),
      loyaltyBonusId: int.parse(json['loyaltyBonusId'].toString())
    );
  }
}