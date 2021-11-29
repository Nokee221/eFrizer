import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:vertical_card_pager/vertical_card_pager.dart';

import 'details.dart';



class HomePage2 extends StatefulWidget {
  const HomePage2({ Key? key }) : super(key: key);

  @override
  _HomePage2State createState() => _HomePage2State();
}

class _HomePage2State extends State<HomePage2> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: bodyWidget(),
    );
  }

   Widget bodyWidget() {
    return FutureBuilder<List<HairSalon>>(
        future: GetHairSalon(),
        builder:
            (BuildContext context, AsyncSnapshot<List<HairSalon>> snapshot) {
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
                children: snapshot.data!.map((e) => HairSalonWidget(e)).toList(),
              );
            }
          }
        });
  }

   Future<List<HairSalon>> GetHairSalon() async {
    

    var hairsalon = await APIService.Get('HairSalon', null);
    if(hairsalon != null){

      return hairsalon.map((i) => HairSalon.fromJson(i)).toList();
    }
    else{
      return List.empty();
    }

  }

  Widget HairSalonWidget(hairsalon) => Padding(
    padding: const EdgeInsets.all(15),
    child: InkWell(
      child: Card(
        color: Colors.lightBlue,
        clipBehavior: Clip.antiAlias,
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(24),
        ),
        child: Column(
          children: [
            Stack(
              children: [
                  Ink.image(
                  image: NetworkImage(
                    'https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg',
                  ),
                  height: 240,
                  fit: BoxFit.cover,
                ),
                Positioned(
                  bottom: 16,
                  right: 16,
                  left: 16,
                  child: Text(
                    hairsalon.Name,
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                      fontSize: 24,
                    ),
                  ),
                ),
              ],
            ),
            Padding(
              padding: EdgeInsets.all(16).copyWith(bottom: 0),
              child: Text(
                hairsalon.Description,
                style: TextStyle(fontSize: 16 , color: Colors.white),
              ),
            ),
            ButtonBar(
              alignment: MainAxisAlignment.start,
              children: [
                FlatButton(
                  child: Text(
                    'Reservation',
                    style: TextStyle(color: Colors.white),
                  ),
                  onPressed: () {

                  },
                ),
              ],
            )
          ],
        ),
      ),
       onTap: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (BuildContext context) {
                return Details(hairsalon);
              },
            ),
          );
        },
    ),
  );


  


}