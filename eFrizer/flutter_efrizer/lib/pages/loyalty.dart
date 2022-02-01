import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user/application_user.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user.dart';
import 'package:flutter_login/models/loyalty_user/loyalty_user_search_request.dart';
import 'package:flutter_login/provider/dark_theme_provider.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';
import 'package:provider/provider.dart';

class LoyaltyPage extends StatefulWidget {
  final LoyaltyBonus loyalty;
  final ApplicationUser user;

  const LoyaltyPage(this.loyalty, this.user, {Key? key}) : super(key: key);

  @override
  _LoyaltyPageState createState() => _LoyaltyPageState(loyalty, user);
}

class _LoyaltyPageState extends State<LoyaltyPage> {
  final LoyaltyBonus loyalty;
  final ApplicationUser user;
  double opacityLevel = 0.0;

  _LoyaltyPageState(this.loyalty, this.user);

  var request = null;
  @override
  void initState() {
    // TODO: implement initState
    request = LoyaltyBonusUserSearchRequest(
        clientId: user.applicationUserId, hairSalonServiceLoyaltyBonusId: loyalty.id);
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    final themeChange = Provider.of<DarkThemeProvider>(context);
    return Scaffold(
      backgroundColor: themeChange.darkTheme ? Colors.black : Colors.white,
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Loyalty bonus",
          style: GoogleFonts.pacifico(color: themeChange.darkTheme ? Colors.white : Colors.black),
        ),
        backgroundColor: themeChange.darkTheme ? Colors.black : Colors.white,
        elevation: 0,
      ),
      body: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: EdgeInsets.only(left: 18, top: 40),
            child: Text(
              "Loyalty bonus",
              style: TextStyle(
                color: themeChange.darkTheme ? Colors.white : Colors.black,
                fontSize: 20,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          SizedBox(height: 15),
          Padding(
            padding: EdgeInsets.only(left: 18),
            child: Text(
              "Description:",
              style: TextStyle(
                color: themeChange.darkTheme ? Colors.white : Colors.black,
                fontSize: 17,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          SizedBox(height: 10),
          Padding(
            padding: EdgeInsets.only(left: 18),
            child: Text(
                "This is your progress of your loyalty bonus for this hairsalon on " +
                    loyalty.serviceName +
                    ", after you collect " +
                    loyalty.activatesOn.toString() +
                    " reservation you will unlock your code with " +
                    loyalty.discount.toString() +
                    "% of discount!"),
          ),
          SizedBox(height: 50),
          Padding(
            padding: EdgeInsets.only(left: 18),
            child: Text("Your progress:",
                style: TextStyle(
                    color: themeChange.darkTheme ? Colors.white : Colors.black,
                    fontSize: 18,
                    fontWeight: FontWeight.bold)),
          ),
          SizedBox(height: 20),
          loyaltyProgress(themeChange),
          
        ],
      ),
    );
  }

  Widget loyaltyProgress(themeChange) {
    return FutureBuilder<List<LoyaltyUser>>(
        future: getLoyaltyBonusesProgress(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<LoyaltyUser>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(child: Text('${snapshot.error}'));
            } else {
              return Column(
                children: snapshot.data!.map((e) => loyaltyBonusProgressWidget(e, themeChange)).toList(),
              );
            }
          }
        });
  }

  Future<List<LoyaltyUser>> getLoyaltyBonusesProgress(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'ClientId': req.clientId.toString(), 'HairSalonServiceLoyaltyBonusId': req.hairSalonServiceLoyaltyBonusId.toString()};

    var loyalty =
        await APIService.get('LoyaltyBonusUser', queryParams);
    return loyalty!.map((i) => LoyaltyUser.fromJson(i)).toList();
  }

  Widget loyaltyBonusProgressWidget(bonus, themeChange) => Column(
        children: [
          Padding(
            padding: const EdgeInsets.only(left: 6, top: 8),
            child: Text(
              "Number of reservation with this service: " + bonus.counter.toString(),
              style: TextStyle(
                color: themeChange.darkTheme ? Colors.white : Colors.black
              ),
            ),
          ),
          Center(
            child: Padding(
              padding: EdgeInsets.only(left: 27, top: 8),
              child: LinearPercentIndicator(
                width: MediaQuery.of(context).size.width - 50,
                animation: true,
                lineHeight: 20.0,
                animationDuration: 2500,
                percent: getProsjek(bonus.counter) > 1.0 ? 1.0 : getProsjek(bonus.counter),
                linearStrokeCap: LinearStrokeCap.roundAll,
                progressColor: Colors.green,
              ),
            ),
          ),
          SizedBox(height: 10),
          Column(
            children: <Widget>[
              Center(
                child: Column(
                  children: [
                    Padding(
                      padding: EdgeInsets.only(left: 18, top: 25),
                      child: TextButton(
                        style:
                            TextButton.styleFrom(backgroundColor: Colors.blue),
                        child: Text(
                          "Generate a code!",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        onPressed: () {
                          setState(() {
                            
                            if(loyalty.activatesOn == bonus.counter || bonus.counter > loyalty.activatesOn)
                            {
                              opacityLevel = 1.0;
                            }
                          });
                        }),
                      ),
                    
                    SizedBox(height: 5),
                    AnimatedOpacity(
                      duration: Duration(seconds: 3),
                      opacity: opacityLevel,
                      child: Text(
                        "CD2523FKP",
                        style: TextStyle(
                            color: Colors.black, fontWeight: FontWeight.bold),
                      ),
                    ),
                  ],
                ),
              ),
            ],
          )
        ],
      );

  double getProsjek(counter) {
    var tempx = 100/loyalty.activatesOn;

    var x = tempx * 0.01;

    return (x * counter);
  }
}


