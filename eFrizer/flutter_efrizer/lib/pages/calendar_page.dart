import 'dart:math';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_custom_clippers/flutter_custom_clippers.dart';
import 'package:flutter_login/models/reservation/reservation.dart';
import 'package:flutter_login/models/reservation/reservation_search_request.dart';
import 'package:flutter_login/pages/payment.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:table_calendar/table_calendar.dart';
import 'package:intl/intl.dart';
import 'dart:math';
import 'package:flutter_staggered_animations/flutter_staggered_animations.dart';


import 'new_reservation.dart';

class CalendarPage extends StatefulWidget {
  final int applicationUserId;
  final int hairdresserId;
  CalendarPage(this.hairdresserId, this.applicationUserId, {Key? key})
      : super(key: key);

  @override
  _CalendarPageState createState() =>
      _CalendarPageState(hairdresserId, applicationUserId);
}

class _CalendarPageState extends State<CalendarPage> {
  final int applicationUserId;
  final int hairdresserId;
  final icon = CupertinoIcons.moon_stars;

  DateTime _dateTime = DateTime.now();
  DateTime focusedDay = DateTime.now();

  var request = null;
  @override
  void initState() {
    super.initState();

    request = ReservationSearchRequest(
        hairdresserId: hairdresserId,
        day: _dateTime.day,
        month: _dateTime.month);
  }

  //CalendarController controller = new CalendarController();
  CalendarFormat format = CalendarFormat.week;

  _CalendarPageState(this.hairdresserId, this.applicationUserId);

  @override
  Widget build(BuildContext context) {
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
        child: Padding(
          padding: const EdgeInsets.fromLTRB(
            20,
            20,
            20,
            0,
          ),
          child: Column(
            children: <Widget>[
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: <Widget>[
                  Text(
                    "${_dateTime.day}.${_dateTime.month}.${_dateTime.year}",
                    style: const TextStyle(
                      fontSize: 30.0,
                      fontWeight: FontWeight.w700,
                    ),
                  ),
                  Container(
                    height: 40.0,
                    width: 160.0,
                    decoration: BoxDecoration(
                      color: Colors.blue,
                      borderRadius: BorderRadius.circular(15),
                    ),
                    child: FlatButton(
                      onPressed: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                              builder: (context) => NewReservation(_dateTime,
                                  hairdresserId, _dateTime, applicationUserId)),
                        );
                      },
                      child: const Center(
                        child: Text(
                          "Add Reservation",
                          style: TextStyle(
                            color: Colors.white,
                            fontWeight: FontWeight.w700,
                            fontSize: 16,
                          ),
                        ),
                      ),
                    ),
                  ),
                ],
              ),
              SizedBox(height: 10),
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: const <Widget>[
                  Text(
                    "Current date",
                    style: TextStyle(
                      fontSize: 18.0,
                      color: Colors.grey,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                ],
              ),
              SizedBox(height: 30),
              TableCalendar(
                focusedDay: DateTime.now(),
                firstDay: DateTime(2020),
                lastDay: DateTime(2030),
                calendarFormat: format,
                onFormatChanged: (CalendarFormat _format) {
                  setState(() {
                    format = _format;
                  });
                },
                startingDayOfWeek: StartingDayOfWeek.sunday,
                daysOfWeekVisible: true,
                onDaySelected: (DateTime selectDay, DateTime focusDay) {
                  setState(() {
                    _dateTime = selectDay;
                    focusDay = focusDay;
                    request = ReservationSearchRequest(
                        hairdresserId: hairdresserId,
                        day: selectDay.day,
                        month: selectDay.month);
                  });
                },
                selectedDayPredicate: (DateTime date) {
                  return isSameDay(_dateTime, date);
                },
                //Calendar style
                calendarStyle: const CalendarStyle(
                  isTodayHighlighted: true,
                  selectedDecoration: BoxDecoration(
                    color: Colors.blue,
                    shape: BoxShape.circle,
                  ),
                  selectedTextStyle: TextStyle(color: Colors.white),
                  todayDecoration: BoxDecoration(
                    color: Colors.grey,
                    shape: BoxShape.circle,
                  ),
                ),
                headerStyle: const HeaderStyle(
                  formatButtonVisible: false,
                  titleCentered: true,
                  formatButtonShowsNext: false,
                ),
              ),
              Divider(
                thickness: 3,
                color: Colors.grey,
              ),
              SizedBox(height: 5),
              Expanded(
                child: AnimationLimiter(
                  child: widgetReservation(),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }

  Widget widgetReservation() {
    return FutureBuilder<List<Reservation>>(
        future: getReservaion(request),
        builder:
            (BuildContext context, AsyncSnapshot<List<Reservation>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              int index = 0;
              index++;
              return ListView(
                children: snapshot.data!.map((e) => ReservationWidget(e, index)).toList()
              );
            }
          }
        });
  }

  Future<List<Reservation>> getReservaion(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {
        'HairDresserId': req.hairdresserId.toString(),
        'Day': req.day.toString(),
        'Month': req.month.toString()
      };

    var hairdresser = await APIService.get('Reservation', queryParams);
    return hairdresser!.map((i) => Reservation.fromJson(i)).toList();
  }

  Widget ReservationWidget(reservation, index) => AnimationConfiguration.staggeredList(
    position: index,
    duration: const Duration(milliseconds: 10000),
    child: SlideAnimation(
        verticalOffset: 50.0,
        child: Container(
        padding: const EdgeInsets.symmetric(horizontal: 20),
        width: MediaQuery.of(context).size.width,
        margin: EdgeInsets.only(bottom: 12),
        child: Container(
          padding: EdgeInsets.all(16),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(16),
            color: Colors.red,
          ),
          child: Row(
            children: [
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.only(left: 20),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        "Reservated",
                        style: GoogleFonts.lato(
                            textStyle: TextStyle(
                                color: Colors.white,
                                fontSize: 16,
                                fontWeight: FontWeight.bold)),
                      ),
                      SizedBox(
                        height: 12,
                      ),
                      Row(
                        crossAxisAlignment: CrossAxisAlignment.center,
                        children: [
                          Icon(
                            Icons.access_time_rounded,
                            color: Colors.grey[200],
                            size: 18,
                          ),
                          SizedBox(width: 4),
                          Text(
                            reservation.To.hour.toString() +
                                ":" +
                                reservation.To.minute.toString() +
                                " - " +
                                reservation.From.hour.toString() +
                                ":" +
                                reservation.From.minute.toString(),
                            style: GoogleFonts.lato(
                              textStyle: TextStyle(
                                fontSize: 15,
                                color: Colors.grey[100],
                              ),
                            ),
                          ),
                        ],
                      )
                    ],
                  ),
                ),
              ),
              Container(
                margin: EdgeInsets.symmetric(horizontal: 10),
                height: 60,
                width: 1,
                color: Colors.grey[200]!.withOpacity(1.0),
              ),
            ],
          ),
        ),
      ),
      ),
    
  );
}
