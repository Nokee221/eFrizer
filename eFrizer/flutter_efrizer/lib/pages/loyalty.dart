import 'package:flutter/material.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:percent_indicator/linear_percent_indicator.dart';

class LoyaltyPage extends StatefulWidget {
  final LoyaltyBonus loyalty;

  const LoyaltyPage(this.loyalty , {Key? key}) : super(key: key);

  @override
  _LoyaltyPageState createState() => _LoyaltyPageState(loyalty);
}

class _LoyaltyPageState extends State<LoyaltyPage> {
  final LoyaltyBonus loyalty;
  double opacityLevel = 0.0;

  _LoyaltyPageState(this.loyalty);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Loyalty bonus",
          style: GoogleFonts.pacifico(color: Colors.black),
        ),
        backgroundColor: Colors.white,
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
                color: Colors.black,
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
                color: Colors.black,
                fontSize: 17,
                fontWeight: FontWeight.bold,
              ),
            ),
          ),
          SizedBox(height: 10),
          Padding(
            padding: EdgeInsets.only(left: 18),
            child: Text(
                "This is your progress of your loyalty bonus for this hairsalon on " + loyalty.serviceName + ", after you collect " + loyalty.activatesOn.toString() + " reservation you will unlock your code with " + loyalty.discount.toString() + "% of discount!"),
          ),
          SizedBox(height: 50),
          Padding(
            padding: EdgeInsets.only(left: 18),
            child: Text("Your progress:",
                style: TextStyle(
                    color: Colors.black,
                    fontSize: 18,
                    fontWeight: FontWeight.bold)),
          ),
          SizedBox(height: 20),
          Column(
            children: [
              Padding(
                padding: const EdgeInsets.only(left: 6, top: 8),
                child: Text(
                  "Number of reservation with this service: ",
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
                    percent: 0.8,
                    center: Text("80.0%"),
                    linearStrokeCap: LinearStrokeCap.roundAll,
                    progressColor: Colors.green,
                  ),
                ),
              ),
            ],
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
                        style: TextButton.styleFrom(backgroundColor: Colors.blue),
                        child: Text(
                          "Generate a code!",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        onPressed: () => setState(() {
                          opacityLevel = 1.0;
                        }),
                      ),
                      
                    ),
                    SizedBox(height: 5),
                    AnimatedOpacity(
                    duration: Duration(seconds: 3),
                    opacity: opacityLevel,
                    child: Text(
                      "CD2523FKP",
                      style: TextStyle(color: Colors.black , fontWeight: FontWeight.bold),
                    ),
                  ),

                  ],
                ),
              ),
            ],
          )
        ],
      ),
    );
  }
}
