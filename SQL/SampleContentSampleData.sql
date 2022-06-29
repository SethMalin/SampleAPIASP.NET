USE ContentSample
GO

DELETE FROM Content

INSERT INTO Content(ContentType, ScreenSpace, [Name], Shape)
VALUES
('Prefab', 'Full', 'MyPrefab', 'Cube'),
('InstantiateAtRuntime', 'Quarter', 'Runtime', 'Capsule'),
('InHierarchy', 'Variable', 'Editor', 'Sphere'),
(null, null, null, null)
SELECT *
FROM Content
