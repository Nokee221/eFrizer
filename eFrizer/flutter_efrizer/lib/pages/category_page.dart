import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/models/hairsalon_hairsalontype/hairsalon_hairsalontype_model.dart';
import 'package:flutter_login/models/hairsalon_hairsalontype/hairsalon_hairsalontype_search_request.dart';
import 'package:flutter_login/models/hairsalon_type.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';

import 'details.dart';


class CategoryPage extends StatefulWidget {
  final ApplicationUser user;
  final HairSalonType hairSalonType;


  const CategoryPage(this.hairSalonType , this.user , { Key? key }) : super(key: key);

  @override
  _CategoryPageState createState() => _CategoryPageState(hairSalonType , user);
}

class _CategoryPageState extends State<CategoryPage> {
  ApplicationUser user;
  HairSalonType hairSalonType;
  final icon = CupertinoIcons.moon_stars;



  _CategoryPageState(this.hairSalonType, this.user);

  var request = null;
  @override
  void initState() {
    super.initState();

    request = HairSalonHairSalonTypeSearchRequest(hairsalontypeId: hairSalonType.hairsalontypeId);
  }
  
  
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Text(hairSalonType.name , style: GoogleFonts.pacifico(color: Colors.black),),
        leading: BackButton(color: Colors.blue),
        backgroundColor: Colors.transparent,
        elevation: 0,
        actions: [
      IconButton(
        icon: Icon(icon),
        color: Colors.blue,
        onPressed: () {},
      ),
      ],
      ),
      body: bodyWidget(),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<HairSalonHairSalonType>>(
        future: getHairSalon(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairSalonHairSalonType>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                scrollDirection: Axis.vertical,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => HairSalonWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairSalonHairSalonType>> getHairSalon(request) async {
    Map<String, String>? queryParams = null;
    if (request != null && queryParams != "")
      queryParams = {'HairSalonTypeId': request.hairsalontypeId.toString()};

    var hairsalon = await APIService.get('HairSalonHairSalonType', queryParams);
    return hairsalon!.map((i) => HairSalonHairSalonType.fromJson(i)).toList();
    
  }

  Widget HairSalonWidget(hairsalon) => Padding(
    padding: const EdgeInsets.all(15),
    child: InkWell(
      child: Card(
        color: Colors.blueGrey,
        clipBehavior: Clip.antiAlias,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(10),
        ),
        child: Column(
          children: [
            Stack(
              children: [
                Ink.image(
                  image: NetworkImage('https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg'),
                  height: 100,
                  fit: BoxFit.cover,
                ),
                Positioned(
                  bottom: 16,
                  right: 16,
                  left: 16,
                  child: Column(
                    children: [
                      Text(
                      hairsalon.hairSalonName,
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                        fontSize: 20,
                      ),
                      ),
                      Text(
                      hairsalon.hairSalonAdress,
                      style: TextStyle(
                        fontWeight: FontWeight.bold,
                        color: Colors.white,
                        fontSize: 10,
                      ),
                      ),
                    ],
                  )
                )
              ],
            )
          ],
        ),
      ),
      onTap: (){
        Navigator.of(context).push(
              MaterialPageRoute(builder: (context) => Details(hairsalon, user)),
            );
      },
    ),
  );
}