import 'package:appcrime/Views/TelaReporte.dart';
import 'package:appcrime/Views/TelaReporteAssalto.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';

class NavBar extends StatelessWidget {
  final String name;
  final String email;

  const NavBar({Key? key, required this.name, required this.email}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
            padding: EdgeInsets.zero,
            children: [
              UserAccountsDrawerHeader(
                accountName: Observer(
                  builder: (_){
                    return Text(name);
                  },
                ),
                accountEmail: Observer(
                  builder: (_){
                    return Text(email);
                  },
                ),
                currentAccountPicture: CircleAvatar(
                  child: ClipOval(
                    child: Image.network(
                      'https://oflutter.com/wp-content/uploads/2021/02/girl-profile.png',
                      fit: BoxFit.cover,
                      width: 90,
                      height: 90,
                    ),
                  ),
                ),
                decoration: BoxDecoration(
                  color: Colors.blue,
                  image: DecorationImage(
                    fit: BoxFit.fill,
                    image: NetworkImage(
                        'https://oflutter.com/wp-content/uploads/2021/02/profile-bg3.jpg'),
                  ),
                ),
              ),
              ListTile(
                leading: Icon(Icons.favorite),
                title: Text('Favoritos'),
                onTap: () => null,
              ),
              ListTile(
                leading: Icon(Icons.share),
                title: Text('Compartilhar'),
                onTap: () => null,
              ),
              ListTile(
                leading: Icon(Icons.notifications),
                title: Text('Notificações'),
                onTap: () => null,
                trailing: ClipOval(
                  child: Container(
                    color: Colors.red,
                    width: 20,
                    height: 20,
                    child: Center(
                      child: Text(
                        '8',
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 12,
                        ),
                      ),
                    ),
                  ),
                ),
              ),
              Divider(),
              ListTile(
                title: Text('Reportar roubo'),
                leading: Icon(Icons.campaign),
                onTap: () {
                  Navigator.pushNamed(
                      context,
                      TelaReporte.routeName,
                      arguments: TelaReporte()
                  );
                },
              ),
              ListTile(
                title: Text('Reportar assalto'),
                leading: Icon(Icons.campaign),
                onTap: () {
                  Navigator.pushNamed(
                      context,
                      TelaReporteAssalto.routeName,
                      arguments: TelaReporteAssalto()
                  );
                },
              ),
              Divider(),
              ListTile(
                leading: Icon(Icons.settings),
                title: Text('Configurações'),
                onTap: () => null,
              ),
              ListTile(
                leading: Icon(Icons.description),
                title: Text('Políticas'),
                onTap: () => null,
              ),
              ListTile(
                leading: Icon(Icons.description),
                title: Text('Sobre nós'),
                onTap: () => null,
              ),
              ListTile(
                leading: Icon(Icons.description),
                title: Text('Números de emergência'),
                onTap: () => null,
              ),
              Divider(),
              ListTile(
                title: Text('Exit'),
                leading: Icon(Icons.exit_to_app),
                onTap: () => null,
              ),
            ],
          )

    );
  }
}
