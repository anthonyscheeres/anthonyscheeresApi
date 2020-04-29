create table app_users (
	id serial PRIMARY KEY,  
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
	token character varying(100) unique,
	password character varying(30),
	username character varying (30) unique,
	email character varying(30),
	is_super_user boolean,
	is_email_verified boolean
);


create table contact_information_owner(
	name character varying(30) not null CHECK (name <> ''),
	place character varying(30) not null  CHECK (place <> ''),
	address character varying(50) not null  CHECK (address <> ''),
	postal_code character varying(30) not null  CHECK (postal_code <> ''),
	
	telephone character varying(30) not null  CHECK (telephone <> ''),
	mail character varying(30) not null  CHECK (mail <> ''),
	
	id serial PRIMARY KEY, 
	created_at TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

insert into contact_information_owner(name, place, address, postal_code , family_name, telephone, mail) values(
	'Anthony Scheeres',
	'Alphen Aan den Rijn',
	'Burgemeester Visserpark 16',
	'2405 CP',
	'+31651076027',
	'info@anthonyscheeres.nl'
		
);

insert into app_users (is_super_user, username, password) values(
	TRUE,
	'admin',
	concat(md5('admin'), md5('the best password in the world'))

);



 
