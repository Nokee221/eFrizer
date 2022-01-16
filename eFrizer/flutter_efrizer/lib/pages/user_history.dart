import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/reservation/reservation.dart';
import 'package:flutter_login/models/reservation/reservation_search_request.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:flutter_slidable/flutter_slidable.dart';
import 'package:provider/provider.dart';


class History extends StatefulWidget {
  final ApplicationUser user;
  const History(this.user, { Key? key }) : super(key: key);

  @override
  _HistoryState createState() => _HistoryState(user);
}

class _HistoryState extends State<History> {
  final ApplicationUser user;
  final icon = CupertinoIcons.moon_stars;

  _HistoryState(this.user);

  var request = null;
  @override
  void initState() {
    super.initState();

    request = ReservationSearchRequest(applicationuserId: user.applicationUserId);
  }

  var result = null;
  Future<void> deleteData(id) async {
    

    result =
        await APIService.delete("Reservation", id.toString());
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        title: Text("History", style: GoogleFonts.pacifico(color: themeChange.darkTheme ? Colors.white : Colors.black),),
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
      body: historyWidget(themeChange),
    );
  }

  Widget historyWidget(themeChange) {
    return FutureBuilder<List<Reservation>>(
        future: GetReservation(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<Reservation>> snapshot) {
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
                children: snapshot.data!.map((e) => HistoryList(e, themeChange)).toList(),
              );
            }
          }
        });
  }

  Future<List<Reservation>> GetReservation(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'ApplicationUserId': req.applicationuserId.toString()};

    var hairsalon = await APIService.get('Reservation', queryParams);
    return hairsalon!.map((i) => Reservation.fromJson(i)).toList();
    
  }

  Widget HistoryList(reservation, themeChange) => Dismissible(
    key: Key(reservation.reservationId.toString()),
    direction: DismissDirection.horizontal,
    onDismissed: (direction){
      setState(() {
        deleteData(reservation.reservationId);
        historyWidget(themeChange);
      });

      ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text("Reservation deleted")));
    },

    background: Container(color: Colors.red),
    child: ListTile(
      contentPadding: EdgeInsets.symmetric(
        horizontal: 20,
        vertical: 10,
        
      ),
      leading: CircleAvatar(
        radius: 20,
        backgroundColor: Colors.transparent,
        backgroundImage: AssetImage(
            "assets/strih.png"
        ),
      ),
      title: Text( reservation.HairDresserName , style: GoogleFonts.nunito(color: themeChange.darkTheme ? Colors.white : Colors.black, fontWeight: FontWeight.bold),),
      subtitle: Text(reservation.To.toString()),
      tileColor: themeChange.darkTheme ? Colors.black87 : Colors.white,
    ),
  );
}