CREATE PROCEDURE sp_select_user_notes(note_id UUID)
LANGUAGE SQL
AS $$
SELECT * from notes 
join users on notes.user_id = users.id
WHERE notes.id = note_id AND notes.is_deleted = false
$$;