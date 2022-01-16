class LoyaltyBonusUserUpdateRequest{
  final int counter;

  LoyaltyBonusUserUpdateRequest({
    required this.counter
  });

  Map<String, dynamic> toJson() => {
        "counter": counter,
      };
}