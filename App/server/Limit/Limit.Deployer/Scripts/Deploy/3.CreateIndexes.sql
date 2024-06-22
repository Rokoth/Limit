--user
create unique index uidx_user_login 
	on "user"("login") where not is_deleted;

create index idx_user_name
    on "user"("name");

create index idx_user_password
    on "user"("password");
   
--user_settings
create index idx_user_settings_userid
	on user_settings(userid) where not is_deleted;

create unique index uidx_user_settings_userid
	on user_settings(userid) where not is_deleted;

--client
--create unique index uidx_client_login 
--	on client("login") where not is_deleted;

--create index idx_client_name
--    on client("name");

--create index idx_client_login_password
--    on client("login", "password");

--create index idx_client_user_id
--    on client(userid);

--create index idx_client_is_deleted
--    on client(is_deleted);



