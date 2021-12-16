import 'dart:async';
import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/service.dart';
import 'package:flutter_login/services/api_service.dart';

class NewReservation extends StatefulWidget {
  const NewReservation({Key? key}) : super(key: key);

  @override
  _NewReservationState createState() => _NewReservationState();
}

class _NewReservationState extends State<NewReservation> {
  late final Service _service;
  List<DropdownMenuItem<Service>> items = [];

  @override
  Widget build(BuildContext context) {
    double width = MediaQuery.of(context).size.width;
    final icon = CupertinoIcons.moon_stars;

    return Scaffold(
      appBar: AppBar(
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
      body: SafeArea(
        child: ListView(
          children: <Widget>[
            SizedBox(height: 30),
            Row(
              mainAxisAlignment: MainAxisAlignment.start,
              children: <Widget>[
                Text(
                  "Make a Reservation",
                  style: TextStyle(
                    fontSize: 30.0,
                    fontWeight: FontWeight.w700,
                  ),
                ),
              ],
            ),
            SizedBox(height: 20),
            Container(
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(
                    "Service",
                  ),
                  dropMenuService(),
                ],
              ),
            )
          ],
        ),
      ),
    );
  }

  Widget dropMenuService() {
    return FutureBuilder<List<Service>>(
        future: GetService(_service),
        builder: (BuildContext context, AsyncSnapshot<List<Service>> snapshot) {
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
              return Padding(
                padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: DropdownButton(
                  hint: Text('Pick service'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                      _service = newVal as Service;
                    });
                  },
                  value: _service,
                ),
              );
            }
          }
        });
  }

  Future<List<Service>> GetService(Service selectedItem) async {
    var Servicelist = await APIService.get('Service', null);
    var ServicelistList = Servicelist!.map((i) => Service.fromJson(i)).toList();

    items = ServicelistList.map((item) {
      return DropdownMenuItem<Service>(
        child: Text(item.Name.toString()),
        value: item,
      );
    }).toList();

    if (selectedItem != null && selectedItem.ServiceId != 0)
      _service = ServicelistList.where(
          (element) => element.ServiceId == selectedItem.ServiceId).first;
    return ServicelistList;
  }
}
