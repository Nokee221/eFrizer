import 'package:flutter/cupertino.dart';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/models/application_user_update_request.dart';
import 'package:flutter_login/pages/profile_page.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/button_widget.dart';
import 'package:flutter_login/widget/profile_widget.dart';

class EditeProfilePage extends StatefulWidget {
  final ApplicationUser user;

  EditeProfilePage(this.user,  {Key? key}) : super(key: key);


  @override
  _EditeProfilePageState createState() => _EditeProfilePageState(user);
}

class _EditeProfilePageState extends State<EditeProfilePage> {
  final icon = CupertinoIcons.moon_stars;
  final ApplicationUser user;

  _EditeProfilePageState(this.user);


  late final TextEditingController usernameController;
  late final TextEditingController nameController;
  late final TextEditingController surnameController;
  late final TextEditingController descriptionController;
  

  @override
  void initState() {
    super.initState();

    usernameController = TextEditingController(text: user.username);
    nameController = TextEditingController(text: user.name);
    surnameController = TextEditingController(text: user.surname);
    descriptionController = TextEditingController(text: user.description);
  }

  @override
  void dispose() {
    usernameController.dispose();
    nameController.dispose();
    surnameController.dispose();
    descriptionController.dispose();

    super.dispose();
  }

 
  var result = null;
  Future<void> PutData() async {
    var req = ApplicationUserUpdateRequest(name: nameController.text , username: usernameController.text, surname: surnameController.text, description: descriptionController.text),
    result = await APIService.Update(
        'ApplicationUser', user.applicationUserId.toString(),
        req);
  }

  @override
  Widget build(BuildContext context) => Builder(


        builder: (context) => Scaffold(
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
          body: ListView(
            padding: EdgeInsets.symmetric(horizontal: 32),
            physics: BouncingScrollPhysics(),
            children: [
              ProfileWidget(
                isEdit: true,
                imagePath:
                    'https://media.istockphoto.com/photos/millennial-male-team-leader-organize-virtual-workshop-with-employees-picture-id1300972574?b=1&k=20&m=1300972574&s=170667a&w=0&h=2nBGC7tr0kWIU8zRQ3dMg-C5JLo9H2sNUuDjQ5mlYfo=',
                onClicked: () async {},
              ),
              const SizedBox(height: 24),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    "Username",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  ),
                  const SizedBox(height: 8),
                  TextField(
                    controller: usernameController,
                    decoration: InputDecoration(
                        border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                    )),
                    maxLines: 1,
                  ),
                  const SizedBox(height: 8),
                  Text(
                    "Name",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  ),
                  const SizedBox(height: 8),
                  TextField(
                    controller: nameController,
                    decoration: InputDecoration(
                        border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                    )),
                    maxLines: 1,
                  ),
                  const SizedBox(height: 8),
                  Text(
                    "Surname",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  ),
                  const SizedBox(height: 8),
                  TextField(
                    controller: surnameController,
                    decoration: InputDecoration(
                        border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                    )),
                    maxLines: 1,
                  ),
                  const SizedBox(height: 8),
                  Text(
                    "About",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                  ),
                  const SizedBox(height: 8),
                  TextField(
                    controller: descriptionController,
                    decoration: InputDecoration(
                        border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(12),
                    )),
                    maxLines: 10,
                  ),
                  const SizedBox(height: 8),
                  ButtonWidget(
                    text: "Save",
                    onClicked: () async {
                      await PutData();
                      if (result != null) {
                        Navigator.push(
                            context,
                            MaterialPageRoute(
                                builder: (context) => ProfilePage(user)));
                      }
                    },
                  )
                ],
              )
            ],
          ),
        ),
      );
}
