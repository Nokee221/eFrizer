class HairSalonPictureIds {
  List<dynamic> pictureIds;

  HairSalonPictureIds({required this.pictureIds});

  factory HairSalonPictureIds.fromJson(Map<String, dynamic> json) {
    return HairSalonPictureIds(
      pictureIds: json["pictureIds"],
    );
  }
}
