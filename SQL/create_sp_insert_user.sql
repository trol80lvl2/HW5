CREATE PROCEDURE sp_insert_note(note_id UUID, note_header varchar(128), note_body varchar(1024), note_user_id integer)
LANGUAGE SQL
AS $$
INSERT INTO notes(id, header, body, user_id) VALUES (note_id, note_header, note_body, note_user_id);
$$;
