import 'package:flutter/material.dart';
import 'package:flutter_login/models/hairsalon/HairSalon.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:provider/provider.dart';
import 'package:vertical_card_pager/vertical_card_pager.dart';

import 'details.dart';

class HomePage2 extends StatefulWidget {
  final ApplicationUser user;
  const HomePage2(this.user , {Key? key}) : super(key: key);

  @override
  _HomePage2State createState() => _HomePage2State(user);
}

class _HomePage2State extends State<HomePage2> {
  final ApplicationUser user;

  _HomePage2State(this.user);
  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Scaffold(
      backgroundColor: Theme.of(context).primaryColor,
      appBar: AppBar(
        centerTitle: true,
        title: Text("Pick your hairsalon" , style: GoogleFonts.pacifico(color: themeChange.darkTheme ? Colors.white : Colors.black, fontSize: 25),),
        backgroundColor: Colors.transparent,
        elevation: 0,
      ),
      body: bodyWidget(),
    );
  }

  Widget bodyWidget() {
    return FutureBuilder<List<HairSalon>>(
        future: getHairSalon(),
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
                children:
                    snapshot.data!.map((e) => HairSalonWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairSalon>> getHairSalon() async {
    var hairsalon = await APIService.get('HairSalon', null);
    if (hairsalon != null) {
      return hairsalon.map((i) => HairSalon.fromJson(i)).toList();
    } else {
      return List.empty();
    }
  }

  Widget HairSalonWidget(hairsalon) => Padding(
        padding: const EdgeInsets.all(15),
        child: InkWell(
          child: Card(
            color: Colors.lightBlue[300],
            clipBehavior: Clip.antiAlias,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.circular(20),
            ),
            child: Column(
              children: [
                Stack(
                  children: [
                    Ink.image(
                      image: NetworkImage(
                        'https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg',
                      ),
                      height: 180,
                      fit: BoxFit.cover,
                    ),
                    Positioned(
                      bottom: 16,
                      right: 16,
                      left: 16,
                      child: Column(
                        children: [
                          Text(
                            hairsalon.Name,
                            style: TextStyle(
                              fontWeight: FontWeight.bold,
                              color: Colors.white,
                              fontSize: 24,
                            ),
                          ),
                          Text(
                            hairsalon.Address,
                            style: TextStyle(
                              fontWeight: FontWeight.bold,
                              color: Colors.white,
                              fontSize: 12,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                Padding(
                  padding: EdgeInsets.all(16).copyWith(bottom: 25),
                  child: Text(
                    hairsalon.Description,
                    style: TextStyle(fontSize: 16, color: Colors.white, fontWeight: FontWeight.bold),
                  ),
                ),
              ],
            ),
          ),
          onTap: () {
            Navigator.of(context).push(
              MaterialPageRoute(
                builder: (BuildContext context) {
                  return Details(hairsalon, user);
                },
              ),
            );
          },
        ),
      );
}
