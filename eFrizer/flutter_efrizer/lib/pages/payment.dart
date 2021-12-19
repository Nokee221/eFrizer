import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/pages/setting_page.dart';
import 'package:flutter_login/pages/success.dart';
import 'package:google_fonts/google_fonts.dart';

import 'credit_card_page.dart';

class Payment extends StatefulWidget {
  const Payment({ Key? key }) : super(key: key);

  @override
  _PaymentState createState() => _PaymentState();
}

class _PaymentState extends State<Payment> {
  final icon = CupertinoIcons.moon_stars;
  Object? value = 0;

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
          onPressed: (){
            if(value == 0)
            {
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => CreditCardPage(),
                ),);

            }
            else{
              Navigator.of(context).push(
                MaterialPageRoute(
                  builder: (context) => Success(),
                ),);
            }
          },
          child: Text("Pay".toUpperCase()),
        ),),
        ],
      ),
    );
  }
}