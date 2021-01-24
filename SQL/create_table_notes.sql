CREATE TABLE notes (
    id  UUID  PRIMARY KEY,
    header  varchar(128) NOT NULL,
    body    varchar(1024) NOT NULL,
	is_deleted bool NOT NULL,
	user_id integer REFERENCES users(Id) NOT NULL,
	modified_at timestamptz DEFAULT CURRENT_TIMESTAMP NOT NULL
);
CREATE INDEX ON notes(modified_at);