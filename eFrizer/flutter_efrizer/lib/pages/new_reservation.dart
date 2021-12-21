import 'package:flutter/foundation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/painting.dart';
import 'package:flutter_login/models/service.dart';
import 'package:flutter_login/pages/payment.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/back_button.dart';
import 'package:flutter_login/widget/my_text_field.dart';
import 'package:flutter_login/widget/top_container.dart';



class NewReservation extends StatefulWidget {
  final DateTime reservationDate;
  const NewReservation(this.reservationDate, {Key? key}) : super(key: key);

  @override
  _NewReservationState createState() => _NewReservationState(reservationDate);
}

class _NewReservationState extends State<NewReservation> {
  late final DateTime reservationDate;
  
  Service? _service = null;
  List<DropdownMenuItem> items = [];

  _NewReservationState(this.reservationDate);

  TextEditingController dateinput = TextEditingController();
  TextEditingController totime = TextEditingController();

  @override
  void initState(){
    dateinput.text = reservationDate.toString();
    totime.text = "";
    super.initState();
  }

  
  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    final icon = CupertinoIcons.moon_stars;

    return Scaffold(
      body: SafeArea(
        child: ListView(
          children: <Widget>[
            TopContainer(
              padding: EdgeInsets.fromLTRB(20, 20, 20, 40),
              width: width,
              child: Column(
                children: <Widget>[
                  MyBackButton(),
                  const SizedBox(
                    height: 30,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.start,
                    children:  const <Widget>[
                       Text(
                        "Create new Reservation",
                        style:  TextStyle(
                          fontSize: 30.0,
                          fontWeight: FontWeight.w700,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(
                    height: 20,
                  ),
                  Container(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: <Widget>[
                        MyTextField(label: "Service"),
                        SizedBox(height: 10),
                        Row(
                          mainAxisAlignment: MainAxisAlignment.start,
                          crossAxisAlignment: CrossAxisAlignment.end,
                          children: <Widget>[
                            Expanded(
                              child: TextField(
                                controller: dateinput,
                                decoration: const InputDecoration(
                                  icon: Icon(Icons.calendar_today),
                                  labelText: 'Date',
                                ),
                                readOnly: true,
                                onTap: (){
                                    DateTime pickedDate = showDatePicker(
                                    context: context,
                                    initialDate: DateTime.now(),
                                    firstDate: DateTime(2020),
                                    lastDate: DateTime(2100),
                                  ) as DateTime;

                                  setState(() {
                                    reservationDate = pickedDate;
                                    dateinput.text = pickedDate.toString();
                                  });
                                },
                              )
                            ),
                          ],
                        )
                      ],
                    ),
                  )
                ],
              ),
            ),
            const SizedBox(height: 25),
            Expanded(
              child: SingleChildScrollView(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Column(
                  children: <Widget>[
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: <Widget>[
                        Expanded(
                          child: TextField(
                            controller: totime,
                            decoration: const InputDecoration(
                              icon: Icon(Icons.timer),
                              labelText: "Start time",
                            ),
                            readOnly: true,
                            onTap: (){
                              DateTime pickedTime = showTimePicker(
                                context: context,
                                initialTime: TimeOfDay.now(),
                          
                              ) as DateTime;
                            },
                          ),
                        ),
                        SizedBox(width: 40),
                        Expanded(
                          child: MyTextField(
                            label: "End Time",
                          ),
                        ),
                      ],
                    ),
                    SizedBox(height: 20),
                    Row(
                      children: [
                      Container(
                      width: 100,
                      child: TextField(
                      style: TextStyle(color: Colors.black87),
                      minLines: 1,
                      maxLines: 1,
                      decoration: InputDecoration(
                        labelText: "Price",
                        labelStyle: TextStyle(
                          color: Colors.black45,
                        ),
                        focusedBorder: UnderlineInputBorder(borderSide: BorderSide(color: Colors.black, width: 2.0)),
                        border: UnderlineInputBorder(borderSide: BorderSide(color: Colors.grey, width: 2.0)),
                      ),
                    ),
                    ),
                      ],
                    ),
                    
                    const SizedBox(height: 100),
                  ],
                ),
              ),
            ),
            Container(
              height: 50,
              width: 160.0,
              padding: EdgeInsets.all(2),
              margin: EdgeInsets.all(20),
              decoration: BoxDecoration(
                color: Colors.blue,
                borderRadius: BorderRadius.circular(15),
              ),
              child: FlatButton(
                onPressed: (){
                  Navigator.of(context).push(
                          MaterialPageRoute(
                              builder: (context) => Payment()),
                        );
                },
                child: const Center(
                  child: Text(
                    "Make a reservation",
                    style: TextStyle(
                      color: Colors.white,
                      fontWeight: FontWeight.w700,
                      fontSize: 16,
                    ),
                  ),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }

}