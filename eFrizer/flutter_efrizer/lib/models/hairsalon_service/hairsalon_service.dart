class HairSalonService{
  final int id;
  final String description;
  final int price;
  final int timeMin;
  final int serviceId;

  HairSalonService({
    required this.id,
    required this.description,
    required this.price,
    required this.serviceId,
    required this.timeMin
  });


  factory HairSalonService.fromJson(Map<String, dynamic> json) {
    return HairSalonService(
      id: int.parse(json['id'].toString()),
      description: json['description'],
      price: int.parse(json['price'].toString()),
      timeMin: int.parse(json['timeMin'].toString()),
      serviceId: int.parse(json['serviceId'].toString())
    );
  }

}