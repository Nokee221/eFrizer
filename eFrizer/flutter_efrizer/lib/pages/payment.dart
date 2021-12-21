import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/reservation/reservation_insert_request.dart';
import 'package:flutter_login/pages/setting_page.dart';
import 'package:flutter_login/pages/success.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'credit_card_page.dart';

class Payment extends StatefulWidget {
  final ReservationInsertRequest request;
  const Payment(this.request , { Key? key }) : super(key: key);

  @override
  _PaymentState createState() => _PaymentState(request);
}

class _PaymentState extends State<Payment> {
  final ReservationInsertRequest request;
  final icon = CupertinoIcons.moon_stars;
  Object? value = 0;

  _PaymentState(this.request);

  final paymentLabels = [
  'Credit card / Debit card',
  'Cash on delivery',
  ];

  final paymentIcons = [
  Icons.credit_card,
  Icons.money_off,
  Icons.payment,
  Icons.account_balance_wallet,
  ];

  var result = null;
  Future<void> getData() async{
    result = await APIService.post("Reservation", request);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: AppBar(
         leading: BackButton(color: Colors.blue),
         centerTitle: true,
        title: Text("Payment", style: GoogleFonts.pacifico(color: Colors.black),),
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
      body: Column(
        children: [
          const Padding(
            padding: const EdgeInsets.all(24.0),
            child: Text(
              "Choose your payment method",
              style: TextStyle(color: Color(0xFF808080) , fontSize: 28.0),
            ),
          ),
          Expanded(
            child: ListView.separated(
              itemCount: paymentLabels.length,
              itemBuilder: (context, index){
                return ListTile(
                  leading: Radio(
                    activeColor: Colors.blue,
                    value: index,
                    groupValue: value,
                    onChanged: (i) => setState(() => value = i),
                  ),
                  title: Text(
                    paymentLabels[index],
                    style: TextStyle(color: Colors.black),
                  ),
                  trailing: Icon(paymentIcons[index], color: Colors.black,),
                );
              },
              separatorBuilder: (context, index){
                return Divider();
              },
            ),
          ),
          Container(
          width: MediaQuery.of(context).size.width,
          margin: EdgeInsets.symmetric(vertical: 24.0),
          padding: EdgeInsets.symmetric(horizontal: 24.0),
          child: FlatButton(
          padding: EdgeInsets.symmetric(vertical: 10.0),
          shape: RoundedRectangleBorder(
            borderRadius: BorderRadius.circular(30.0)),
          color: Colors.blue,
          textColor: Color(0xFFFFFFFF),
          highlightColor: Colors.transparent,
          onPressed: () async{
            if(value == 0)
            {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => CreditCardPage(),
                ),);

            }
            else{
              await getData();
              if(result != null)
              {
                Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (context) => Success(),
                  ),);
              }
              else{
                Widget okButton = TextButton(
                      child: Text("OK"),
                      onPressed: () {},
                    );
                    AlertDialog alert = AlertDialog(
                      title: Text("Error"),
                      content: Text("Bezuspjesna rezervacija"),
                      actions: [
                        okButton,
                      ],
                    );
                    showDialog(
                        context: context,
                        builder: (BuildContext context) {
                          return alert;
                        });
              }
            }
          },
          child: Text("Pay".toUpperCase()),
        ),),
        ],
      ),
    );
  }
}