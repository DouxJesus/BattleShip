def placementcreatexml():
	res = ""
	res += '<Grid x:Name="Grid" Width="300" Height="300" VerticalAlignment="Top" Margin="0,60,60.4,0" \n Background="#FFEDDBDB">\n'
	res += '<Grid.ColumnDefinitions>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '</Grid.ColumnDefinitions>\n'
	res +=    '<Grid.RowDefinitions>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=    '</Grid.RowDefinitions>'

	for i in range(0,100):
		res += '<Border Grid.Row="' 
		res +=  str(i // 10)
		res += '" Grid.Column="' 
		res += str(i % 10) + '" HorizontalAlignment="Left" VerticalAlignment="Top"  BorderBrush="White" BorderThickness="1">'
		res += '<Grid Name="grid' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" \n'
		res +=   'Height="30" Width="30" MouseDown="gridMouseDown" \n' 
		res += 'Background="#00436b">\n' 
		res += '<Rectangle MouseDown="gridMouseDown"/>\n' 
		res += '<Path Name="cell' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" />\n' 
		res += '</Grid>\n'
		res += '</Border>\n'

	return res 

def shipcreatexml():
	res = ""
	res += '<Grid x:Name="myGrid" Width="300" Height="300" VerticalAlignment="Top" Margin="0,60,400,0" \n Background="#FFEDDBDB">\n'
	res += '<Grid.ColumnDefinitions>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '</Grid.ColumnDefinitions>\n'
	res +=    '<Grid.RowDefinitions>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=    '</Grid.RowDefinitions>'

	for i in range(0,100):
		res += '<Border Grid.Row="' 
		res +=  str(i // 10)
		res += '" Grid.Column="' 
		res += str(i % 10) + '" HorizontalAlignment="Left" VerticalAlignment="Top"  BorderBrush="#81CEF5" BorderThickness="1">'
		res += '<Grid Name="myGrid' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" \n'
		res +=   'Height="30" Width="30" \n' 
		res += 'Background="#00436b">\n' 
		res += '<Path Name="myCell' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" />\n' 
		res += '</Grid>\n'
		res += '</Border>\n'

	return res  + '</Grid>\n'

def opponentcreatexml():
	res = ""
	res += '<Grid x:Name="OpponentGrid" Width="300" Height="300" VerticalAlignment="Top" Margin="400,60,0,0" \n Background="#FFEDDBDB">\n'
	res += '<Grid.ColumnDefinitions>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '<ColumnDefinition></ColumnDefinition>\n'
	res += '</Grid.ColumnDefinitions>\n'
	res +=    '<Grid.RowDefinitions>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=        '<RowDefinition></RowDefinition>\n'
	res +=    '</Grid.RowDefinitions>'

	for i in range(0,100):
		res += '<Border Grid.Row="' 
		res +=  str(i // 10)
		res += '" Grid.Column="' 
		res += str(i % 10) + '" HorizontalAlignment="Left" VerticalAlignment="Top"  BorderBrush="White" BorderThickness="1">'
		res += '<Grid Name="oppGrid' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" \n'
		res +=   'Height="30" Width="30" MouseDown="oppGridMouseDown" \n' 
		res += 'Background="#00436b">\n' 
		res += '<Rectangle MouseDown="oppGridMouseDown"/>\n' 
		res += '<Path Name="oppCell' + chr(ord('A') + i // 10) + str(1 + i % 10) + '" />\n' 
		res += '</Grid>\n'
		res += '</Border>\n'

	return res + '</Grid>\n'

def myGrid(mygrid):
	res = ""
	res += 'OppGrid = new Grid[]{'
	for i in range(0,100):
		res += mygrid + chr(ord('A') + i // 10) + str(1 + i % 10) + " ,"
		if(i % 10 == 9):
			res += '\n'
	res += '};'
	print(res)


print(shipcreatexml())
print(opponentcreatexml())

#myGrid("oppGrid")